using WenasRoomForRent.Domain;
using WenasRoomForRent.Repository;

namespace WenasRoomForRent.Services;

public class PaymentService : IPaymentService
{
    private readonly IPaymentRepository repository;
    private readonly IRentRepository rentRepository;

    public PaymentService(IPaymentRepository repository, IRentRepository rentRepository)
    {
        this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
        this.rentRepository = rentRepository ?? throw new ArgumentNullException(nameof(rentRepository));
    }

    public Payment Create(Payment payment) => repository.Create(payment);

    public void DeleteById(int id) => repository.DeleteById(id);

    public IEnumerable<Payment> FilterByPaidDate(DateTime? startDate, DateTime? endDate) => repository.FilterByPaidDate(startDate, endDate);

    public IEnumerable<Payment> FilterByPaidDate(int month, int year) => repository.FilterByPaidDate(month, year);

    public IEnumerable<Payment> FilterByStatus(PaymentStatus status) => repository.FilterByStatus(status);

    public IEnumerable<Payment> FindByProfileId(int profileId)
    {
        return repository.GetAll().Where(p =>
        {
            var rent = rentRepository.GetById(p.rentId);
            if (rent != null)
            {
                return rent.profileId == profileId;
            }
            return false;
        });
    }

    public IEnumerable<Payment> FindByRoomId(int roomId)
    {
        return repository.GetAll().Where(p =>
        {
            var rent = rentRepository.GetById(p.rentId);
            if (rent != null)
            {
                return rent.roomId == roomId;
            }
            return false;
        });
    }

    public IEnumerable<Payment> GetAll() => repository.GetAll();

    public Payment GetById(int id) => repository.GetById(id);

    public void Update(Payment payment) => repository.Update(payment);

    public void UpdateStatus(int id, PaymentStatus status) => repository.UpdateStatus(id, status);
}
