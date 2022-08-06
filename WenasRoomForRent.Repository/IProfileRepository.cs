using WenasRoomForRent.Domain;

namespace WenasRoomForRent.Repository;

public interface IProfileRepository
{
    public IEnumerable<Profile> GetAll();
    public IEnumerable<Profile> Find(string name);
    public Profile GetById(int id);
    public Profile Create(Profile profile);
    public void Update(Profile profile);
    public void Delete(int id);
}
