using Microsoft.EntityFrameworkCore;
using WenasRoomForRent.Domain;

namespace WenasRoomForRent.Repository;

public class AppEFContext : DbContext
{
    public AppEFContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        foreach (var property in modelBuilder.Model.GetEntityTypes()
                .SelectMany(t => t.GetProperties())
                .Where(p => p.ClrType == typeof(decimal) || p.ClrType == typeof(decimal?)))
        {
            property.SetColumnType("decimal(18,2)");
        }
    }

    public DbSet<Room> Rooms { get; set; }
    public DbSet<Profile> Profiles { get; set; }
    public DbSet<Rent> Rents { get; set; }
    public DbSet<Payment> Payments { get; set; }
}
