using WenasRoomForRent.Domain;
using WenasRoomForRent.Repository;

namespace WenasRoomForRent.Services;

public class ProfileService : IProfileService
{
    private readonly IProfileRepository repository;
    private readonly IRentRepository rentRepository;

    public ProfileService(IProfileRepository repository, IRentRepository rentRepository)
    {
        this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
        this.rentRepository = rentRepository ?? throw new ArgumentNullException(nameof(rentRepository));
    }

    public Profile Create(Profile profile) => repository.Create(profile);

    // TODO : Check if profile is being referenced
    public void Delete(int id) => repository.Delete(id);

    public IEnumerable<Profile> Find(string name) => repository.Find(name);

    public IEnumerable<Profile> FindByRoomId(int id) => rentRepository.GetAllByRoomId(id).Select(r => repository.GetById(r.profileId));

    public IEnumerable<Profile> GetAll() => repository.GetAll();

    public Profile GetById(int id) => repository.GetById(id);

    public void Update(Profile profile) => repository.Update(profile);
}
