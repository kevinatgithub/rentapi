using WenasRoomForRent.Domain;

namespace WenasRoomForRent.Services;

public interface IPaymentService
{
    public IEnumerable<Payment> GetAll();

    public IEnumerable<Payment> FindByRoomId(int roomId);

    public IEnumerable<Payment> FindByProfileId(int profileId);

    public IEnumerable<Payment> FilterByPaidDate(DateTime? startDate, DateTime? endDate);

    public IEnumerable<Payment> FilterByStatus(PaymentStatus status);

    public Payment GetById(int id);

    public Payment Create(Payment payment);

    public void UpdateStatus(int id, PaymentStatus status);

    public void Update(Payment payment);

    public void DeleteById(int id);
}
