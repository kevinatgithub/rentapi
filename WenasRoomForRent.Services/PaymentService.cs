using WenasRoomForRent.Domain;
using WenasRoomForRent.Repository;

namespace WenasRoomForRent.Services;

public class PaymentService : IPaymentService
{
    private readonly IPaymentRepository repository;
    private readonly IRentRepository rentRepository;
    private readonly IRoomRepository roomRepository;
    private readonly IProfileRepository profileRepository;

    public PaymentService(IPaymentRepository repository, IRentRepository rentRepository, IRoomRepository roomRepository, IProfileRepository profileRepository)
    {
        this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
        this.rentRepository = rentRepository ?? throw new ArgumentNullException(nameof(rentRepository));
        this.roomRepository = roomRepository ?? throw new ArgumentNullException(nameof(roomRepository));
        this.profileRepository = profileRepository ?? throw new ArgumentNullException(nameof(profileRepository));
    }

    public Payment Create(Payment payment) => repository.Create(payment);

    public void DeleteById(int id) => repository.DeleteById(id);

    public IEnumerable<Payment> FilterByPaidDate(DateTime? startDate, DateTime? endDate) => repository.FilterByPaidDate(startDate, endDate);

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

    public void Print(int id)
    {
        var payment = repository.GetById(id);
        if (payment != null)
        {
            payment.LastPrintDate = DateTime.UtcNow;
            payment.PrintedTime += 1;
            repository.Update(payment);
        }
    }

    public IEnumerable<Payment> Search(string term)
    {
        var payments = GetAll();
        var npayments = new List<Payment>();

        if (term != "")
        {
            foreach (var pay in payments)
            {
                var rent = rentRepository.GetById(pay.rentId);
                var profile = profileRepository.GetById(rent.profileId);
                var room = roomRepository.GetById(rent.roomId);
                if (profile.Name.Contains(term, StringComparison.InvariantCultureIgnoreCase) || room.Name.Contains(term, StringComparison.InvariantCultureIgnoreCase)){
                    npayments.Add(pay);
                }
            }
        }
        else
        {
            npayments = payments.ToList();
        }

        return npayments;
    }

    public void Update(Payment payment) => repository.Update(payment);

    public void UpdateStatus(int id, PaymentStatus status) => repository.UpdateStatus(id, status);
}
