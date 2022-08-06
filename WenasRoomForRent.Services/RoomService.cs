using WenasRoomForRent.Domain;
using WenasRoomForRent.Repository;

namespace WenasRoomForRent.Services;

public class RoomService : IRoomService
{
    private readonly IRoomRepository repository;

    public RoomService(IRoomRepository repository)
    {
        this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
    }

    public Room Create(Room room) => repository.Create(room);

    // TODO : Check if room is in use
    public void Delete(int id) => repository.Delete(id);

    public IEnumerable<Room> GetAll() => repository.GetAll();

    public Room GetById(int id) => repository.GetById(id);

    public void Update(Room room) => repository.Update(room);
}
