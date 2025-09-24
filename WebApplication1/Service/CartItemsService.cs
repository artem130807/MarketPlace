using AutoMapper;
using WebApplication1.Contracts.ContractsBasket;
using WebApplication1.Contracts.ContractsCart;
using WebApplication1.DtoModels.DtoAppUser;
using WebApplication1.DtoModels.DtoBasket;
using WebApplication1.Models;

namespace WebApplication1.Service
{
    public class CartItemsService : ICartService
    {
        private readonly ICartRepository _cartRepository;
        private readonly IMapper _mapper;
        public CartItemsService(ICartRepository cartRepository, IMapper mapper)
        {
            _cartRepository = cartRepository;
            _mapper = mapper;
        }
        public async Task<List<DtoCartResponce>> GetCartItemsByUsers(Guid userId)
        {
            var cart = await _cartRepository.GetCartItemsByUsers(userId);
            return _mapper.Map<List<DtoCartResponce>>(cart);
        }
    }
}
