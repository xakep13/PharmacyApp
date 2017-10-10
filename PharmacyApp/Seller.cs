class Seller
{
    public int Id { get; set; }
    public int Name { get; set; }

    public int? OrderId { get; set; }
    public Order Order { get; set; }
}

