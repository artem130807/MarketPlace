using WebApplication1.DtoModels.DtoBook;
using WebApplication1.Models;

namespace WebApplication1.DtoModels.DtoBasket
{
    public class DtoCart
    {
        public Guid UserId { get; set; }
        public List<DtoCartResponce> Items { get; set; } = new();
        public decimal TotalAmount => Items.Sum(x => x.BookPrice * x.Quantity);
    }
}
