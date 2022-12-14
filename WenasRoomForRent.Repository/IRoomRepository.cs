using WenasRoomForRent.Domain;

namespace WenasRoomForRent.Repository;

public interface IRoomRepository
{
    public IEnumerable<Room> GetAll();
    public IEnumerable<Room> GetByName(string name);
    public Room GetById(int id);
    public Room Create(Room room);
    public void Update(Room room);
    public void Delete(int id);
}
