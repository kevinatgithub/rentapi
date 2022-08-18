using WenasRoomForRent.Domain;

namespace WenasRoomForRent.Repository.SqlDB;

public class RentRepository : IRentRepository
{
    private readonly AppEFContext context;

    public RentRepository(AppEFContext context)
    {
        this.context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public Rent Create(Rent rent)
    {
        var r = context.Rents.Add(rent);
        context.SaveChanges();
        return r.Entity;
    }

    public void Delete(int id)
    {
        var rent = context.Rents.FirstOrDefault(rent => rent.Id == id);
        if (rent != null)
        {
            context.Rents.Remove(rent);
            context.SaveChanges();
        }
    }

    public IEnumerable<Rent> GetAll() => context.Rents.ToList();

    public IEnumerable<Rent> GetAllByRoomId(int id) => context.Rents.Where(r => r.roomId == id && r.Status == RentStatus.Active).ToList();

    public Rent GetById(int id) => context.Rents.FirstOrDefault(r => r.Id == id);

    public void Update(Rent rent)
    {
        var nrent = context.Rents.FirstOrDefault(r => r.Id == rent.Id);
        if (nrent != null)
        {
            nrent.Remarks = rent.Remarks;
            nrent.Status = rent.Status;
            nrent.EndDateTime = rent.EndDateTime;
            nrent.StartDateTime = rent.StartDateTime;
            nrent.profileId = rent.profileId;
            nrent.roomId = rent.roomId;
            context.SaveChanges();
        }
    }

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
