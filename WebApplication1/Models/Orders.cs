namespace WebApplication1.Models
{
    public class Orders
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.Now; 
        public decimal TotalSum { get; set; }
        public status Status { get; set; }
        public Guid UserId { get; set; }
        public AppUsers AppUsers { get; set; }
        public string ShippingAddress {  get; set; }
        public ICollection<OrderItems> Items { get; set; }

    }
    public enum status
    {
        Pending, Confirmed, Shipped, Delivered
    }
}
