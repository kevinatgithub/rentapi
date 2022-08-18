using Microsoft.AspNetCore.Mvc;
using WenasRoomForRent.Api.Filters;
using WenasRoomForRent.Api.Models;
using WenasRoomForRent.Domain;
using WenasRoomForRent.Services;

namespace WenasRoomForRent.Api.Controllers;

[RequestLogger]
[Route("api/[controller]")]
[ApiController]
public class PaymentsController : ControllerBase
{
    private readonly IPaymentService paymentService;
    private readonly IRentService rentService;
    private readonly IRoomService roomService;

    public PaymentsController(IPaymentService paymentService, IRentService rentService, IRoomService roomService)
    {
        this.paymentService = paymentService ?? throw new ArgumentNullException(nameof(paymentService));
        this.rentService = rentService ?? throw new ArgumentNullException(nameof(rentService));
        this.roomService = roomService ?? throw new ArgumentNullException(nameof(roomService));
    }

    [HttpGet]
    public IActionResult GetAll() => Ok(paymentService.GetAll());

    [HttpGet("findByRoomId/{roomId}")]
    public IActionResult FindByRoomId(int roomId) => Ok(paymentService?.FindByRoomId(roomId));

    [HttpGet("findByProfileId/{profileId}")]
    public IActionResult FindByProfileId(int profileId) => Ok(paymentService?.FindByProfileId(profileId));

    [HttpPost("findByDate")]
    public IActionResult FilterByPaidDate(FilterPaymentByDateModel model) => Ok(paymentService?.FilterByPaidDate(model?.StartDate, model?.EndtDate));

    [HttpGet("findByStatus/{status}")]
    public IActionResult FilterByStatus(string status)
    {
        Enum.TryParse(status, out PaymentStatus stat);
        return Ok(paymentService.FilterByStatus(stat));
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id) => Ok(paymentService.GetById(id));

    [HttpPost]
    public IActionResult Create(CreatePaymentModel model)
    {
        var rent = rentService.GetById(model.rentId);
        if (rent == null)
            return BadRequest();

        var room = roomService.GetById(rent.roomId);
        if (room == null)
            return BadRequest();

        decimal totalAmount = room.PricePerMonth;
        decimal paidAmount = model.PaidAmount;
        var payment = new Payment
        {
            rentId = rent.Id,
            TotalAmount = totalAmount,
            PaidAmount = paidAmount,
            Balance = totalAmount - paidAmount,
            PaidDateTime = DateTime.UtcNow,
            PeriodCoveredStartDate = model.PeriodStartDateTime,
            PeriodCoveredEndDate = model.PeriodEndDateTime,
            Status = PaymentStatus.Recieved
        };
        return Ok(paymentService.Create(payment));
    }

    [HttpPost("log")]
    public IActionResult Log(LogPaymentModel model)
    {
        var rent = rentService.GetById(model.rentId);
        if (rent == null)
            return BadRequest();

        var room = roomService.GetById(rent.roomId);
        if (room == null)
            return BadRequest();

        decimal totalAmount = room.PricePerMonth;
        decimal paidAmount = 0;
        var payment = new Payment
        {
            rentId = rent.Id,
            TotalAmount = totalAmount,
            PaidAmount = paidAmount,
            Balance = totalAmount - paidAmount,
            PaidDateTime = DateTime.UtcNow,
            PeriodCoveredStartDate = model.PeriodStartDateTime,
            PeriodCoveredEndDate = model.PeriodEndDateTime,
            Status = PaymentStatus.Pending
        };
        return Ok(paymentService.Create(payment));
    }

    [HttpPost("{id}/pay")]
    public IActionResult Pay(int id, decimal amount)
    {
        var payment = paymentService.GetById(id);
        if (payment == null)
            return BadRequest();

        payment.PaidAmount += amount;
        payment.Balance = payment.TotalAmount - payment.PaidAmount;
        payment.Status = payment.Balance == 0 ? PaymentStatus.Recieved : PaymentStatus.Pending;
        payment.PaidDateTime = DateTime.UtcNow;
        paymentService.Update(payment);
        return Ok(payment);
    }

    [HttpPut]
    public IActionResult Update(Payment payment)
    {
        var pyment = paymentService.GetById(payment.Id);
        if (pyment == null)
            return BadRequest();

        paymentService.Update(payment);
        return Ok();
    }

    [HttpDelete]
    public IActionResult DeleteById(int id)
    {
        paymentService.DeleteById(id);
        return Ok();
    }
}
