﻿class Seller
{
    public int Id { get; set; }
    public string Name { get; set; }

    public int? OrderId { get; set; }
    public Order Order { get; set; }
}

