using AutoMapper;
using System.Net.WebSockets;
using WebApplication1.Contracts.ContractsBasket;
using WebApplication1.Contracts.ContractsCart;
using WebApplication1.DtoModels.DtoAppUser;
using WebApplication1.DtoModels.DtoBasket;
using WebApplication1.DtoModels.DtoCart;
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

        public async Task<DtoCartResponce> AddCartItem(DtoCartCreate dtoCartCreate)
        {
            var items = _mapper.Map<CartItems>(dtoCartCreate);
            var create = await _cartRepository.AddCartItem(items);
            return _mapper.Map<DtoCartResponce>(create);
        }

        public async Task DeleteCartItem(Guid UserId, int id)
        {
            await _cartRepository.DeleteCartItem(UserId, id);
        }

        public async Task<CartItems> GetCartItemByIdCart(Guid UserId, int id)
        {
            var item = await _cartRepository.GetCartItemByIdCart(UserId, id); 
            return item;         
        }

        public async Task<List<DtoCartResponce>> GetCartItemsByUsers(Guid userId)
        {
            var cart = await _cartRepository.GetCartItemsByUsers(userId);
            return _mapper.Map<List<DtoCartResponce>>(cart);
        }

        public async Task UpdateCartItem(Guid UserId, int CartId,  int Quantity)
        {
            await _cartRepository.UpdateCartItem(UserId, CartId, Quantity);          
        }
    }
}
