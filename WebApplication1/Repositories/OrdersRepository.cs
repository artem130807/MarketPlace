using Microsoft.EntityFrameworkCore;
using WebApplication1.Contracts.ContractsOrderItems;
using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public class OrdersRepository : IOrdersRepository
    {
        private readonly MarketPlaceDbContext _marketPlaceDbContext;
        public OrdersRepository(MarketPlaceDbContext marketPlaceDbContext)
        {
            _marketPlaceDbContext = marketPlaceDbContext;
        }

        public async Task<Orders> CreateOrder(Guid userId, string shippingAddress)
        {
            var cartItem = await _marketPlaceDbContext.CartItems.Include(x => x.Book).Include(x => x.User).Where(x => x.UserId == userId).ToListAsync();
            var order = new Orders
            {
                UserId = userId,
                OrderDate = DateTime.Now,
                ShippingAddress = shippingAddress,
                Status = status.Pending,
                Items = new List<OrderItems>()
            };
            foreach(var item in cartItem)
            {
                var orderItem = new OrderItems
                {
                    BookId = item.BookId,
                    Quantity = item.Quantity,
                    UnitPrice = item.Book.Price,
                };
                order.Items.Add(orderItem);
                order.TotalSum += orderItem.Quantity * orderItem.UnitPrice;
            }
            _marketPlaceDbContext.Add(order);
            _marketPlaceDbContext.CartItems.RemoveRange(cartItem);
            await _marketPlaceDbContext.SaveChangesAsync();
            return order;
    
        }

        public async Task<Orders> GetOrdersById(int orderId, Guid userId)
        {
            var order = await _marketPlaceDbContext.Orders
                .Include(x => x.Items)
                .ThenInclude(x => x.Book)
                .Include(x => x.AppUsers)
                .FirstOrDefaultAsync(x => x.Id == orderId && x.UserId == userId);
            return order;
        }

        public async Task<List<Orders>> GetOrdersItems(Guid userId)
        {
            return await _marketPlaceDbContext.Orders.Where(x => x.UserId == userId)
                .Include(x => x.Items).ThenInclude(x => x.Book).Include(x => x.AppUsers).ToListAsync();
        }

        public async Task UpdateOrder(int orderId, status? status)
        {
            await _marketPlaceDbContext.Orders.Where(x => x.Id == orderId)
                .ExecuteUpdateAsync(x => x.SetProperty(x => x.Status, status));
        }
    }
}
