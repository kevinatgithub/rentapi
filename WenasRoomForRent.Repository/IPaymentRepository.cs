using WenasRoomForRent.Domain;

namespace WenasRoomForRent.Repository;

public interface IPaymentRepository
{
    public IEnumerable<Payment> GetAll();

    public IEnumerable<Payment> FilterByPaidDate(DateTime? startDate, DateTime? endDate);
    
    public IEnumerable<Payment> FilterByPaidDate(int month, int year);

    public IEnumerable<Payment> FilterByStatus(PaymentStatus status);

    public Payment GetById(int id);

    public Payment Create(Payment payment);

    public void UpdateStatus(int id, PaymentStatus status);

    public void Update(Payment payment);

    public void DeleteById(int id);
}
