using Microsoft.EntityFrameworkCore;
using WebApplication1.Contracts.ContractsCart;
using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public class CartItemsRepository:ICartRepository
    {
        private readonly MarketPlaceDbContext _context;
        public CartItemsRepository(MarketPlaceDbContext context)
        {
            _context = context;
        }

      
        public async Task<List<CartItems>> GetCartItemsByUsers(Guid userId)
        {
            return await _context.CartItems.Where(x => x.UserId == userId).Include(x => x.User).Include(x => x.Book).ToListAsync();
        }     
    }
}
