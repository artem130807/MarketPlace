namespace WebApplication1.Models
{
    public class OrderItems
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public int BookId { get; set; }  
        public Books Book { get; set; } 
        public int OrderId { get; set; }
        public Orders Orders { get; set; }
    }
}
