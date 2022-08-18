using WenasRoomForRent.Domain;

namespace WenasRoomForRent.Repository;

public class AppInMemoryContext
{
    public List<Room> Rooms { get; set; } = new List<Room>();
    public List<Profile> Profiles { get; set; } = new List<Profile>();
    public List<Rent> Rents { get; set; } = new List<Rent>();
    public List<Payment> Payments { get; set; } = new List<Payment>();
    public List<(string, DateTime)> RequestLogs = new List<(string, DateTime)>();
}
