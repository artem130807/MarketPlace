using AutoMapper;
using WebApplication1.Contracts.ContractsOrderItems;
using WebApplication1.DtoModels.DtoOrders;
using WebApplication1.Models;

namespace WebApplication1.Service
{
    public class OrdersService : IOrdersService
    {
        private readonly IOrdersRepository _ordersRepository;
        private readonly IMapper _mapper;
        
        public OrdersService(IOrdersRepository ordersRepository, IMapper mapper)
        {
            _ordersRepository = ordersRepository;
            _mapper = mapper;
        }

        public async Task<DtoOrders> CreateOrder(Guid userId, string shippingAddress)
        {
            var order = await _ordersRepository.CreateOrder(userId, shippingAddress);
            return _mapper.Map<DtoOrders>(order);
        }

        public async Task<DtoOrders> GetOrdersById(int orderId, Guid userId)
        {
            var order = await _ordersRepository.GetOrdersById(orderId, userId);
            return _mapper.Map<DtoOrders>(order);
        }

        public async Task<List<DtoOrders>> GetOrdersItems(Guid userId)
        {
            var order = await _ordersRepository.GetOrdersItems(userId);
            return _mapper.Map<List<DtoOrders>>(order);
        }

        public async Task UpdateOrder(int orderId, status? status)
        {
            await _ordersRepository.UpdateOrder(orderId, status);
        }
    }
}
