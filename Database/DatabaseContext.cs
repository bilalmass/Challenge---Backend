using Microsoft.EntityFrameworkCore;
using Models;

namespace Database;

public class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
    optionsBuilder.UseSqlite("Data Source=database.db");

    public DbSet<DeliveryAddress> DeliveryAddresses {get; set;}
    public DbSet<Dimension> Dimensions {get; set;}
    public DbSet<Parcel> Parcels {get; set;}


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Parcel>()
            .HasKey(p => p.TrackingNumber);
    }
}