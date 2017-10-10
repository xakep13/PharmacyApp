using PharmacyApp;
using System.Data.Entity;

class MyContextInitializer : DropCreateDatabaseAlways<PharmacyContext>
{
    protected override void Seed(PharmacyContext db)
    {
        Drug d1 = new Drug { Title = "Мезим", description = "Перша допомога" };
        Drug d2 = new Drug { Title = "Вугілля активоване", description = "Перша допомога" };

        db.Drugs.Add(d1);
        db.Drugs.Add(d2);
        db.SaveChanges();

        Customer c1 = new Customer { Name = "Вася" };
        Customer c2 = new Customer { Name = "Петя" };

        db.Customers.Add(c1);
        db.Customers.Add(c2);
        db.SaveChanges();

        Seller s1 = new Seller { Name = "Галина" };
        Seller s2 = new Seller { Name = "Марина" };

        db.Sellers.Add(s1);
        db.Sellers.Add(s2);
        db.SaveChanges();
    }
}