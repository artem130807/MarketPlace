using WebApplication1.Models;

namespace WebApplication1.Contracts.ContractsCart
{
    public interface ICartRepository
    {
        public Task<List<CartItems>> GetCartItemsByUsers(Guid userId);
        public Task<CartItems> AddCartItem(CartItems cartItem);
        public Task DeleteCartItem(Guid UserId, int id);
        public Task<CartItems> GetCartItemByIdCart(Guid UserId, int id);
        public Task UpdateCartItem(Guid UserId, int CartId, int Quantity);
    }
}
