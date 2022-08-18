using WenasRoomForRent.Domain;

namespace WenasRoomForRent.Services;

public interface IRoomService
{
    public IEnumerable<Room> GetAll();
    public IEnumerable<Room> GetByName(string name);
    public IEnumerable<Room> GetByProfileId(int id);
    public Room GetById(int id);
    public Room Create(Room room);
    public void Update(Room room);
    public void Delete(int id);
}
