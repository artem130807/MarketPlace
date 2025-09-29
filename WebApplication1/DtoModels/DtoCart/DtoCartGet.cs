using WebApplication1.Models;

namespace WebApplication1.DtoModels.DtoCart
{
    public class DtoCartGet
    {
        public int Id { get; set; }
        public int Quantity { get; set; }   
        public Books Book { get; set; }     
        public AppUsers User { get; set; }
    }
}
