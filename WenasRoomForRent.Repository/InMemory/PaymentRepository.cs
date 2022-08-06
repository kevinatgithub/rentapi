using WenasRoomForRent.Domain;

namespace WenasRoomForRent.Repository.InMemory;

public class PaymentRepository : IPaymentRepository
{
    private readonly AppInMemoryContext context;

    public PaymentRepository(AppInMemoryContext context)
    {
        this.context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public Payment Create(Payment payment)
    {
        payment.Id = context.Payments.Any() ? context.Payments.Max(p => p.Id) + 1 : 1;
        context.Payments.Add(payment);
        return payment;
    }

    public void DeleteById(int id)
    {
        var payment = context.Payments.FirstOrDefault(p => p.Id.Equals(id));
        if (payment != null)
        {
            context.Payments.Remove(payment);
        }
    }

    public IEnumerable<Payment> FilterByPaidDate(DateTime? startDate, DateTime? endDate)
    {
        var payments = context.Payments;
        if ( startDate.HasValue)
        {
            payments = payments.Where(p => p.PaidDateTime >= startDate).ToList();
        }
        if (endDate.HasValue)
        {
            payments = payments.Where(p => p.PaidDateTime <= endDate).ToList();
        }
        return payments;
    }

    public IEnumerable<Payment> FilterByPaidDate(int month, int year) => context.Payments.Where(p => p.PaidForTheYearOf.Equals(year) && p.PaidForTheMonthOf.Equals(month));

    public IEnumerable<Payment> FilterByStatus(PaymentStatus status) => context.Payments.Where(p => p.Status.Equals(status));

    public IEnumerable<Payment> GetAll() => context.Payments;

    public Payment GetById(int id) => context.Payments.FirstOrDefault(p => p.Id.Equals(id));

    public void Update(Payment payment)
    {
        var npayment = context.Payments.FirstOrDefault(p => p.Id.Equals(payment.Id));
        if (npayment != null)
        {
            npayment.TotalAmount = payment.TotalAmount;
            npayment.Balance = payment.Balance;
            npayment.PaidAmount = payment.PaidAmount;
            npayment.PaidDateTime = payment.PaidDateTime;
            npayment.PaidForTheMonthOf = payment.PaidForTheMonthOf;
            npayment.PaidForTheYearOf = payment.PaidForTheYearOf;
            npayment.rentId = payment.rentId;
            npayment.Status = payment.Status;
        }
    }

    public void UpdateStatus(int id, PaymentStatus status)
    {
        var npayment = context.Payments.FirstOrDefault(p => p.Id.Equals(id));
        if (npayment != null)
        {
            npayment.Status = status;
        }
    }
}
