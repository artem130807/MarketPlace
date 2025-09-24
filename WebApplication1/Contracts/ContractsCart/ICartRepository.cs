using WebApplication1.Models;

namespace WebApplication1.Contracts.ContractsCart
{
    public interface ICartRepository
    {
        public Task<List<CartItems>> GetCartItemsByUsers(Guid userId);
    }
}
