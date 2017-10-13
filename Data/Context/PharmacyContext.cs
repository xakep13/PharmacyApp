using System.Data.Entity;

namespace DataLibrery
{
    public class PharmacyContext : DbContext
    {
        static PharmacyContext()
        {
            Database.SetInitializer<PharmacyContext>(new MyContextInitializer());
        }
        public PharmacyContext() : base("PharmacyDb") { }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Drug> Drugs { get; set; }
        public DbSet<Seller> Sellers { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
