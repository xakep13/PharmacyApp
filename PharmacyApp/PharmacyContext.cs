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

        DbSet<Supplier> Supppliers { get; set; }
        DbSet<Customer> Customers { get; set; }
    }
}
