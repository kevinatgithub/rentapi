using WenasRoomForRent.Domain;

namespace WenasRoomForRent.Repository.SqlDB;

public class ProfileRepository : IProfileRepository
{
    private readonly AppEFContext context;

    public ProfileRepository(AppEFContext context)
    {
        this.context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public Profile Create(Profile profile)
    {
        var p = context.Profiles.Add(profile);
        context.SaveChanges();
        return p.Entity;
    }

    public void Delete(int id)
    {
        var profile = context.Profiles.FirstOrDefault(p => p.Id == id);
        if (profile != null)
        {
            context.Profiles.Remove(profile);
            context.SaveChanges();
        }
    }

    public IEnumerable<Profile> Find(string name) => context.Profiles.Where(p => p.Name.Contains(name)).OrderBy(p => p.Name).ToList();

    public IEnumerable<Profile> GetAll() => context.Profiles.OrderBy(p => p.Name).ToList();

    public Profile GetById(int id) => context.Profiles.FirstOrDefault(p => p.Id == id);

    public void Update(Profile profile)
    {
        var nprofile = context.Profiles.FirstOrDefault(p => p.Id == profile.Id);
        if (nprofile != null)
        {
            nprofile.ContactNumber = profile.ContactNumber;
            nprofile.Name = profile.Name;
            nprofile.Gender = profile.Gender;
            context.SaveChanges();
        }
    }
}
