using WenasRoomForRent.Domain;

namespace WenasRoomForRent.Services;

public interface IRoomService
{
    public IEnumerable<Room> GetAll();
    public Room GetById(int id);
    public Room Create(Room room);
    public void Update(Room room);
    public void Delete(int id);
}
