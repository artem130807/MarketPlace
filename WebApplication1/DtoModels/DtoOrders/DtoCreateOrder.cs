using WebApplication1.DtoModels.DtoOrderItems;

namespace WebApplication1.DtoModels.DtoOrders
{
    public class DtoCreateOrder
    {
        public string ShippingAddress { get; set; }
        public List<DtoOrderItem> Items { get; set; }
    }
}
