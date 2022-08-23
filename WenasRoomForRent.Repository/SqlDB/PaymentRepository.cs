using WenasRoomForRent.Domain;

namespace WenasRoomForRent.Repository.SqlDB;

public class PaymentRepository : IPaymentRepository
{
    private readonly AppEFContext context;

    public PaymentRepository(AppEFContext context)
    {
        this.context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public Payment Create(Payment payment)
    {
        var p = context.Payments.Add(payment);
        context.SaveChanges();
        return p.Entity;
    }

    public void DeleteById(int id)
    {
        var payment = context.Payments.Find(id);
        if (payment != null)
        {
            context.Payments.Remove(payment);
            context.SaveChanges();
        }
    }

    public IEnumerable<Payment> FilterByPaidDate(DateTime? startDate, DateTime? endDate)
    {
        var payments = context.Payments.AsQueryable();
        if (startDate.HasValue)
        {
            payments = payments.Where(p => p.PaidDateTime >= startDate);
        }
        if (endDate.HasValue)
        {
            payments = payments.Where(p => p.PaidDateTime <= endDate);
        }
        return payments.ToList();
    }

    public IEnumerable<Payment> FilterByStatus(PaymentStatus status) => context.Payments.Where(p => p.Status.Equals(status)).ToList();

    public IEnumerable<Payment> GetAll() => context.Payments.OrderByDescending(p => p.PaidDateTime).ToList();

    public Payment GetById(int id) => context.Payments.Find(id);

    public void Update(Payment payment)
    {
        var npayment = context.Payments.FirstOrDefault(p => p.Id.Equals(payment.Id));
        if (npayment != null)
        {
            npayment.TotalAmount = payment.TotalAmount;
            npayment.Balance = payment.Balance;
            npayment.PaidAmount = payment.PaidAmount;
            npayment.PaidDateTime = payment.PaidDateTime;
            npayment.PeriodCoveredStartDate = payment.PeriodCoveredStartDate;
            npayment.PeriodCoveredEndDate = payment.PeriodCoveredEndDate;
            npayment.rentId = payment.rentId;
            npayment.Status = payment.Status;
            npayment.Particulars = payment.Particulars;
            npayment.PaymentForRoom = payment.PaymentForRoom;
            context.SaveChanges();
        }
    }

    public void UpdateStatus(int id, PaymentStatus status)
    {
        var npayment = context.Payments.FirstOrDefault(p => p.Id.Equals(id));
        if (npayment != null)
        {
            npayment.Status = status;
            context.SaveChanges();
        }
    }
}
