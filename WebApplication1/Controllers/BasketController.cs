using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WebApplication1.Contracts.ContractsBasket;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class BasketController : ControllerBase
    {
        private readonly ICartService _cartService;
        public BasketController(ICartService cartService) 
        { 
            _cartService = cartService; 
        
        }
        [HttpGet("cart-items")]
        public async Task<IActionResult> GetCartItems()
        {
            var userId = Guid.Parse(User.FindFirstValue("userId"));        
            var items = await _cartService.GetCartItemsByUsers(userId);
            return Ok(items);
        }
    }
}
