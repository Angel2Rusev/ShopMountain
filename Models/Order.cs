namespace PROJECT_ANGEL.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string ZipCode { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public string PaymentMethod { get; set; } = string.Empty;
        public List<CartItem> Items { get; set; } = new List<CartItem>();
        public decimal TotalAmount { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.UtcNow;
    }
}
