using PharmacyApp;
using System;
using System.Collections.Generic;

class Order
{
    public int OrderId { get; set; }
    public DateTime Date { get; set; }

    public ICollection<Customer> Customers { get; set; }
    public ICollection<Seller> Sellers { get; set; }
    public ICollection<Drug> Drugs { get; set; }

    public Order()
    {
        Customers = new List<Customer>();
        Sellers = new List<Seller>();
        Drugs = new List<Drug>();
    }

}

