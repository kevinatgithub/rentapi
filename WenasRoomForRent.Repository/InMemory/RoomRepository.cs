using WenasRoomForRent.Domain;

namespace WenasRoomForRent.Repository.InMemory;

public class RoomRepository : IRoomRepository
{
    private readonly AppInMemoryContext context;

    public RoomRepository(AppInMemoryContext context)
    {
        this.context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public Room Create(Room room)
    {
        room.Id = context.Rooms.Any() ? context.Rooms.Max(r => r.Id) + 1 : 1;
        context.Rooms.Add(room);
        return room;
    }

    public void Delete(int id)
    {
        var room = context.Rooms.FirstOrDefault(r => r.Id == id);
        if (room != null)
        {
            context.Rooms.Remove(room);
        }
    }

    public IEnumerable<Room> GetAll() => context.Rooms.ToList();

    public Room GetById(int id) => context.Rooms.FirstOrDefault(r => r.Id == id);

    public void Update(Room room)
    {
        var nroom = context.Rooms.FirstOrDefault(r => r.Id == room.Id);
        if (nroom != null)
        {
            nroom.Remarks = room.Remarks;
            nroom.PricePerMonth = room.PricePerMonth;
            nroom.Name = room.Name;
        }
    }
}
