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

        public async Task<CartItems> AddCartItem(CartItems cartItem)
        {
           _context.CartItems.Add(cartItem);
            await _context.SaveChangesAsync();
            return cartItem;
        }

        public async Task DeleteCartItem(Guid UserId, int id)
        {
          
            await _context.CartItems.Where(x => x.Id == id && x.UserId == UserId).ExecuteDeleteAsync();    
        }

        public async Task<CartItems> GetCartItemByIdCart(Guid UserId, int id)
        {
            var item = await _context.CartItems.FirstOrDefaultAsync(x => x.Id == id && x.UserId == UserId);
            return item;
        }

        public async Task<List<CartItems>> GetCartItemsByUsers(Guid userId)
        {
            return await _context.CartItems.Where(x => x.UserId == userId).Include(x => x.User).Include(x => x.Book).ToListAsync();
        }

        public async Task UpdateCartItem(Guid UserId, int CartId, int Quantity)
        {
             await _context.CartItems.Where(x => x.UserId == UserId && x.Id == CartId)
            .ExecuteUpdateAsync(x => x.SetProperty(x => x.Quantity, Quantity));       
        }
    }
}
