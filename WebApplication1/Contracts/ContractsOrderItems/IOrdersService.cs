using WebApplication1.Configurations;
using WebApplication1.DtoModels.DtoOrders;
using WebApplication1.Models;

namespace WebApplication1.Contracts.ContractsOrderItems
{
    public interface IOrdersService
    {
        public Task<List<DtoOrders>> GetOrdersItems(Guid userId);
        public Task<DtoOrders> GetOrdersById(int orderId,Guid userId);
        public Task<DtoOrders> CreateOrder(Guid userId, string shippingAddress);
        public Task UpdateOrder(int orderId, status? status);
    }
}
