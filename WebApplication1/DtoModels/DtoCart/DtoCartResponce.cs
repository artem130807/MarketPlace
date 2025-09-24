using WebApplication1.DtoModels.DtoAppUser;
using WebApplication1.DtoModels.DtoBook;

namespace WebApplication1.DtoModels.DtoBasket
{
    public class DtoCartResponce
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public int BookId { get; set; }
        public string BookTitle { get; set; } = default!;    
        public decimal BookPrice { get; set; }
    }
}
