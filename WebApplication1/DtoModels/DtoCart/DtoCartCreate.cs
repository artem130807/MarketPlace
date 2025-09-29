using WebApplication1.Models;

namespace WebApplication1.DtoModels.DtoBasket
{
    public class DtoCartCreate
    {
        public int Quantity { get; set; }
        public int BookId { get; set; }
        public Books Book { get; set; }
        public Guid UserId { get; set; }
        public AppUsers User { get; set; }
    }
}
