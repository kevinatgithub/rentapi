using WenasRoomForRent.Domain;
using WenasRoomForRent.Repository;

namespace WenasRoomForRent.Services;

public class RoomService : IRoomService
{
    private readonly IRoomRepository repository;
    private readonly IRentService rentService;

    public RoomService(IRoomRepository repository, IRentService rentService)
    {
        this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
        this.rentService = rentService ?? throw new ArgumentNullException(nameof(rentService));
    }

    public Room Create(Room room) => repository.Create(room);

    // TODO : Check if room is in use
    public void Delete(int id) => repository.Delete(id);

    public IEnumerable<Room> GetAll() => repository.GetAll();

    public Room GetById(int id) => repository.GetById(id);

    public IEnumerable<Room> GetByName(string name) => repository.GetByName(name);

    public IEnumerable<Room> GetByProfileId(int id)
    {
        var rents = rentService.FindByProfileId(id);
        return rents.Select(r => repository.GetById(r.roomId));
    }

    public void Update(Room room) => repository.Update(room);
}
