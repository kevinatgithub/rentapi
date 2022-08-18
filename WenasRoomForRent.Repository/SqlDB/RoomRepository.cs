using WenasRoomForRent.Domain;

namespace WenasRoomForRent.Repository.SqlDB;

public class RoomRepository : IRoomRepository
{
    private readonly AppEFContext context;

    public RoomRepository(AppEFContext context)
    {
        this.context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public Room Create(Room room)
    {
        var r = context.Rooms.Add(room);
        context.SaveChanges();
        return r.Entity;
    }

    public void Delete(int id)
    {
        var room = context.Rooms.FirstOrDefault(r => r.Id == id);
        if (room != null)
        {
            context.Rooms.Remove(room);
            context.SaveChanges();
        }
    }

    public IEnumerable<Room> GetAll() => context.Rooms.ToList();

    public Room GetById(int id) => context.Rooms.FirstOrDefault(r => r.Id == id);

    public IEnumerable<Room> GetByName(string name) => context.Rooms.Where(r => r.Name.Contains(name, StringComparison.InvariantCultureIgnoreCase)).ToList();

    public void Update(Room room)
    {
        var nroom = context.Rooms.FirstOrDefault(r => r.Id == room.Id);
        if (nroom != null)
        {
            nroom.Remarks = room.Remarks;
            nroom.PricePerMonth = room.PricePerMonth;
            nroom.Name = room.Name;
            context.SaveChanges();
        }
    }
}
