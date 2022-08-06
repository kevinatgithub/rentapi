using WenasRoomForRent.Domain;

namespace WenasRoomForRent.Repository.InMemory;

public class ProfileRepository : IProfileRepository
{
    private readonly AppInMemoryContext context;

    public ProfileRepository(AppInMemoryContext context)
    {
        this.context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public Profile Create(Profile profile)
    {
        profile.Id = context.Profiles.Any() ? context.Profiles.Max(r => r.Id) + 1 : 1;
        context.Profiles.Add(profile);
        return profile;
    }

    public void Delete(int id)
    {
        var profile = context.Profiles.FirstOrDefault(p => p.Id == id);
        if (profile != null)
        {
            context.Profiles.Remove(profile);
        }
    }

    public IEnumerable<Profile> Find(string name) => context.Profiles.Where(p => p.Name.Contains(name, StringComparison.InvariantCultureIgnoreCase));

    public IEnumerable<Profile> GetAll() => context.Profiles;

    public Profile GetById(int id) => context.Profiles.FirstOrDefault(p => p.Id == id);

    public void Update(Profile profile)
    {
        var nprofile = context.Profiles.FirstOrDefault(p => p.Id == profile.Id);
        if (nprofile != null)
        {
            nprofile.ContactNumber = profile.ContactNumber;
            nprofile.Name = profile.Name;
            nprofile.Gender = profile.Gender;
        }
    }
}
