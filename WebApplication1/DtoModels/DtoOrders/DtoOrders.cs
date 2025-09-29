using WebApplication1.DtoModels.DtoAppUser;
using WebApplication1.DtoModels.DtoOrderItems;
using WebApplication1.Models;

namespace WebApplication1.DtoModels.DtoOrders
{
    public class DtoOrders
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.Now;
        public decimal TotalSum { get; set; }
        public string Status { get; set; } = default!;
        public DtoUserShortInfo AppUsers { get; set; }
        public string ShippingAddress { get; set; }
        public List<DtoOrderItem> Items { get; set; }

    }
}
