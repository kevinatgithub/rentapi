using WenasRoomForRent.Domain;

namespace WenasRoomForRent.Repository;

public interface IRentRepository
{
    public IEnumerable<Rent> GetAll();
    public IEnumerable<Rent> GetAllByRoomId(int id);
    public Rent GetById(int id);
    public Rent Create(Rent rent);
    public void Update(Rent rent);
    public void Delete(int id);
}
