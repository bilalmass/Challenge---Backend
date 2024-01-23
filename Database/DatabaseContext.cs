using Microsoft.EntityFrameworkCore;
using Models;

namespace Database;

public class DatabaseContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
    optionsBuilder.UseSqlite("Data Source=database.db");

    public DbSet<DeliveryAddress> DeliveryAddresses {get; set;}
    public DbSet<Dimension> Dimensions {get; set;}
    public DbSet<Parcel> Parcels {get; set;}
   
}