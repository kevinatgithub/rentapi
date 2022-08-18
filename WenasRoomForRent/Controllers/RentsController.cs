using Microsoft.AspNetCore.Mvc;
using WenasRoomForRent.Api.Filters;
using WenasRoomForRent.Api.Models;
using WenasRoomForRent.Domain;
using WenasRoomForRent.Services;

namespace WenasRoomForRent.Api.Controllers;

[RequestLogger]
[Route("api/[controller]")]
[ApiController]
public class RentsController : ControllerBase
{
    private readonly IRentService rentService;
    private readonly IRoomService roomService;
    private readonly IProfileService profileService;

    public RentsController(IRentService rentService, IRoomService roomService, IProfileService profileService)
    {
        this.rentService = rentService ?? throw new ArgumentNullException(nameof(rentService));
        this.roomService = roomService ?? throw new ArgumentNullException(nameof(roomService));
        this.profileService = profileService ?? throw new ArgumentNullException(nameof(profileService));
    }

    [HttpGet]
    public IActionResult GetAll() => Ok(rentService.GetAll());

    [HttpGet("findByProfileId/{id}")]
    public IActionResult GetByProfileId(int id) => Ok(rentService.FindByProfileId(id));

    [HttpGet("findByRoomId/{roomId}")]
    public IActionResult GetByRoomId(int id) => Ok(rentService.FindByRoomId(id));

    [HttpPost("filterByDate")]
    public IActionResult GetByDate(FilterByDateModel filter) => Ok(rentService.FilterByDate(filter.StartDate, filter.EndDate));

    [HttpGet("{id}")]
    public IActionResult GetById(int id) => Ok(rentService.GetById(id));

    [HttpPut("{id}/status/{status}")]
    public IActionResult UpdateStatus(int id, string status)
    {
        Enum.TryParse(status, out RentStatus stat);
        rentService.UpdateStatus(id, stat);
        return Ok();
    }

    //public void UpdateStatus(Rent rent, RentStatus status);

    [HttpPut("{id}/room/{roomId}")]
    public IActionResult UpdateRoom(int id, int roomId)
    {
        rentService.UpdateRoom(id, roomId);
        return Ok();
    }

    [HttpPut("{id}/profile/{profileId}")]
    public IActionResult UpdateProfile(int id, int profileId)
    {
        rentService.UpdateProfile(id, profileId);
        return Ok();
    }

    [HttpPut]
    public IActionResult Update(Rent rent)
    {
        rentService.Update(rent);
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        rentService?.Delete(id);
        return Ok();
    }

    //[HttpPost]
    //public IActionResult Create(Rent rent) => Ok(rentService.Create(rent));

    [HttpPost]
    public IActionResult Register(RegisterRentModel model)
    {
        var profile = profileService.GetById(model.profileId);
        var room = roomService.GetById(model.roomId);

        if (profile == null || room == null)
            return BadRequest();

        var rent = new Rent
        {
            roomId = room.Id,
            profileId = profile.Id,
            StartDateTime = model.startDate,
            Remarks = model.Remarks
        };

        return Ok(rentService.Create(rent));
    }

    [HttpPut("terminate")]
    public IActionResult TerminateRent(TerminateModel model)
    {
        var rents = rentService.FindByProfileId(model.ProfileId);
        if (!rents.Any())
        {
            return Ok();
        }

        var rent = rents.FirstOrDefault(r => r.roomId == model.RoomId && r.Status == RentStatus.Active);
        if (rent != null)
        {
            rent.Status = RentStatus.Inactive;
            rent.EndDateTime = DateTime.UtcNow;
            rentService.Update(rent);
        }
        return Ok();
    }
}
