using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Formats.Asn1;
using System.Security.Claims;
using WebApplication1.Contracts.ContractsBasket;
using WebApplication1.Contracts.ContractsBook;
using WebApplication1.DtoModels.DtoBasket;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class BasketController : ControllerBase
    {
        private readonly ICartService _cartService;
        private readonly IBooksService _booksService;
        public BasketController(ICartService cartService, IBooksService booksService) 
        { 
            _cartService = cartService; 
            _booksService = booksService;
        
        }
        [HttpGet("cart-items")]
        public async Task<IActionResult> GetCartItems()
        {
            var userId = Guid.Parse(User.FindFirstValue("userId"));        
            var items = await _cartService.GetCartItemsByUsers(userId);
            return Ok(items);
        }
        [HttpPost("add-cartItems")]
        public async Task<IActionResult> AddItemsInCart(int Quantity, string Title)
        {
            var book = await _booksService.GetBookByTitle(Title);    
            if(book == null)
            {
                return BadRequest("Книга не найдена");
            }         
            if(Quantity == 0)
            {
                return BadRequest("Количество должно быть больше нуля");
            }
            if (string.IsNullOrWhiteSpace(Quantity.ToString()))
            {
                return BadRequest("Вы не указали количество");
            }
            var userId = Guid.Parse(User.FindFirstValue("userId"));
            var items = new DtoCartCreate { Quantity = Quantity, BookId = book.Id, UserId = userId };
            var createitem = await _cartService.AddCartItem(items);
            return Ok(createitem);
        }
        [HttpDelete("delete-cartItem")]
        public async Task<IActionResult> Delete(int CartId)
        {
            
            var userId = Guid.Parse(User.FindFirstValue("userId"));
            var item = await _cartService.GetCartItemByIdCart(userId, CartId);
            if(item != null)
            {
                await _cartService.DeleteCartItem(userId, CartId);
                return Ok();
            }
            else
            {
                return BadRequest("Такого элемента нету в корзине");
            }
           
        }

        [HttpPut("update-QuantityCartItem")]
        public async Task<IActionResult> Update(int CartId, int Quantity)
        {
            var userId = Guid.Parse(User.FindFirstValue("userId"));
            var item = await _cartService.GetCartItemByIdCart(userId, CartId);
            if (item != null)
            {
                await _cartService.UpdateCartItem(userId, CartId, Quantity);
                return Ok("Успешно");
            }
            else
            {
                return BadRequest("Такого элемента нету в корзине");
            }
        }
    }
}
