using System.Collections.Generic;

class Drug
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string description { get; set; }
    public double Price { get; set; }

    public ICollection<Order> Orders { get; set; }

    public Drug()
    {
        Orders = new List<Order>();

    }

}

