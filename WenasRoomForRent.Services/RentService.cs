using WenasRoomForRent.Domain;
using WenasRoomForRent.Repository;

namespace WenasRoomForRent.Services;

public class RentService : IRentService
{
    private readonly IRentRepository repository;
    private readonly IProfileRepository profileRepository;
    private readonly IRoomRepository roomRepository;

    public RentService(IRentRepository repository, IProfileRepository profileRepository, IRoomRepository roomRepository)
    {
        this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
        this.profileRepository = profileRepository ?? throw new ArgumentNullException(nameof(profileRepository));
        this.roomRepository = roomRepository ?? throw new ArgumentNullException(nameof(roomRepository));
    }

    public Rent Create(Rent rent) => repository.Create(rent);

    public void Delete(int id) => repository.Delete(id);

    public IEnumerable<Rent> FilterByDate(DateTime? startDate, DateTime? endDate)
    {
        var rents = repository.GetAll();
        if (startDate.HasValue)
        {
            rents.Where(r => r.StartDateTime >= startDate);
        }
        if (endDate.HasValue)
        {
            rents.Where(r => r.EndDateTime <= endDate);
        }
        return rents;
    }

    public IEnumerable<Rent> FindByProfileId(int profileId) => repository.GetAll().Where(r => r.profileId.Equals(profileId));

    public IEnumerable<Rent> FindByRoomId(int roomId) => repository.GetAll().Where(r => r.roomId.Equals(roomId));

    public IEnumerable<Rent> GetAll() => repository.GetAll();

    public Rent GetById(int id) => repository.GetById(id);

    public void Update(Rent rent) => repository.Update(rent);

    public void UpdateProfile(int id, int profileId)
    {
        var rent = repository.GetById(id);
        var profile = profileRepository.GetById(profileId);
        if (rent != null && profile != null)
        {
            rent.profileId = profileId;
            repository.Update(rent);
        }
    }

    public void UpdateRoom(int id, int roomId)
    {
        var rent = repository.GetById(id);
        var room = roomRepository.GetById(roomId);
        if (rent != null && room != null)
        {
            rent.roomId = roomId;
            repository.Update(rent);
        }
    }

    public void UpdateStatus(int id, RentStatus status)
    {
        var rent = repository.GetById(id);
        if (repository.GetById(id) != null)
        {
            rent.Status = status;
            repository.Update(rent);
        }
    }

    public void UpdateStatus(Rent rent, RentStatus status)
    {
        rent.Status = status;
        repository.Update(rent);
    }
}
