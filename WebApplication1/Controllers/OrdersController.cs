using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;
using System.Security.Claims;
using WebApplication1.Contracts.ContractsOrderItems;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class OrdersController : ControllerBase
    {
        private readonly IOrdersService _ordersService;
        public OrdersController(IOrdersService ordersService)
        {
            _ordersService = ordersService;
        }
        [HttpGet("Get-Orders")]
        public async Task<IActionResult> GetOrders()
        {
            var userId = Guid.Parse(User.FindFirstValue("userId"));
            var orders = await _ordersService.GetOrdersItems(userId);
            return Ok(orders);
        }
        [HttpGet("Get-OrdersById")]
        public async Task<IActionResult> GetOrderById(int orderId)
        {
            var userId = Guid.Parse(User.FindFirstValue("userId"));
            var order = await _ordersService.GetOrdersById(orderId, userId);
            return Ok(order);
        }
        [HttpGet("Add-Order")]
        public async Task<IActionResult> CreateOrder(string shippingAddress)
        {
            var userId = Guid.Parse(User.FindFirstValue("userId"));
            var order = await _ordersService.CreateOrder(userId, shippingAddress);
            return Ok(order);
        }
    }
}
