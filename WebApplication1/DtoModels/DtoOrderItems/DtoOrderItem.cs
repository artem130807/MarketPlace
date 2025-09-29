using WebApplication1.DtoModels.DtoBook;

namespace WebApplication1.DtoModels.DtoOrderItems
{
    public class DtoOrderItem
    {
        public DtoBookShortInfo BookShortInfo { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
