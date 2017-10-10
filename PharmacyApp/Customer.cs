namespace PharmacyApp
{
    internal class Customer
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }

        public int? OrderId { get; set; }
        public Order Order { get; set; }
    }
}