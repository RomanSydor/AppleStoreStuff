using Microsoft.EntityFrameworkCore;

namespace AppleStoreStuff.Models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
          : base(options)
        {
        }

        public DbSet<IPhone> IPhones { get; set; }
        public DbSet<IPad> IPads { get; set; }
        public DbSet<Mac> Macs { get; set; }
        public DbSet<AppleWatch> AppleWatches { get; set; }
        public DbSet<AirPods> AirPodses { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<Discount> Discounts { get; set; }
    }
}
