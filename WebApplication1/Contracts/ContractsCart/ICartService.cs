using Microsoft.Data.SqlClient.DataClassification;
using WebApplication1.DtoModels.DtoAppUser;
using WebApplication1.DtoModels.DtoBasket;
using WebApplication1.DtoModels.DtoCart;
using WebApplication1.Models;

namespace WebApplication1.Contracts.ContractsBasket
{
    public interface ICartService
    {
        public Task<List<DtoCartResponce>> GetCartItemsByUsers(Guid userId);
        public Task<DtoCartResponce> AddCartItem(DtoCartCreate dtoCartCreate);
        public Task DeleteCartItem(Guid UserId, int id);
        public Task<CartItems> GetCartItemByIdCart(Guid UserId, int id);
        public Task UpdateCartItem(Guid UserId, int CartId, int Quantity);
    }    
}
