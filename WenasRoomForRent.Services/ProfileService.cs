﻿using WenasRoomForRent.Domain;
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

    public IEnumerable<Profile> Find(string name)
    {
        var profiles = repository.GetAll();
        var result = new List<Profile>();
        foreach(var profile in profiles)
        {
            if (profile.Name.Contains(name, StringComparison.InvariantCultureIgnoreCase) || (profile.Remarks != null ? profile.Remarks.Contains(name,StringComparison.InvariantCultureIgnoreCase) : false ) )
            {
                result.Add(profile);
            } else
            {
                var rents = rentRepository.GetAllByProfileId(profile.Id);
                foreach(var rent in rents)
                {
                    if (rent.Remarks.Contains(name, StringComparison.InvariantCultureIgnoreCase))
                    {
                        result.Add(profile);
                        continue;
                    }
                }
            }
            
        }
        return result;
    }

    public IEnumerable<Profile> FindByRoomId(int id) => rentRepository.GetAllByRoomId(id).Select(r => repository.GetById(r.profileId));

    public IEnumerable<Profile> GetAll() => repository.GetAll();

    public Profile GetById(int id) => repository.GetById(id);

    public void Update(Profile profile) => repository.Update(profile);
}
