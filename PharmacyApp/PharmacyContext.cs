using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyApp
{
    class PharmacyContext :DbContext
    {
        public PharmacyContext() : base("PharmacyDb") { }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Drug> Drugs { get; set; }
        public DbSet<Seller> Sellers { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
