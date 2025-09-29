using WebApplication1.Models;

namespace WebApplication1.Contracts.ContractsOrderItems
{
    public interface IOrdersRepository
    {
        public Task<List<Orders>> GetOrdersItems(Guid userId);
        public Task<Orders> CreateOrder(Guid userId, string shippingAddress);
        public Task<Orders> GetOrdersById(int orderId, Guid userId);
        public Task UpdateOrder(int orderId, status? status);
    }
}
