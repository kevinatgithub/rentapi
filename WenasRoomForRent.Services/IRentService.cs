using WenasRoomForRent.Domain;

namespace WenasRoomForRent.Services;

public interface IRentService
{
    public IEnumerable<Rent> GetAll();
    public IEnumerable<Rent> FindByProfileId(int profileId);
    public IEnumerable<Rent> FindByRoomId(int roomId);
    public IEnumerable<Rent> FilterByDate(DateTime? startDate, DateTime? endDate);
    public Rent GetById(int id);
    public void UpdateStatus(int id, RentStatus status);
    public void UpdateStatus(Rent rent, RentStatus status);
    public void UpdateRoom(int id, int roomId);
    public void UpdateProfile(int id, int profileId);
    public void Update(Rent rent);
    public void Delete(int id);
    public Rent Create(Rent rent);
}
