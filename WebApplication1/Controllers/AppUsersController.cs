using Microsoft.AspNetCore.Mvc;
using WebApplication1.Contracts.ContractsAppUser;
using WebApplication1.DtoModels.DtoAppUser;
using WebApplication1.Models;
using WebApplication1.Service;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AppUsersController : ControllerBase
    {
        private readonly IUserService _userService;
        public AppUsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequestDto registerRequestDto)
        {
            var result = await _userService.CreateUser(registerRequestDto);
            Response.Cookies.Append("tasty", result.Token, new CookieOptions
            {
                HttpOnly = true,
                Secure = true,
                SameSite = SameSiteMode.Strict,
                Expires = DateTime.UtcNow.AddHours(12)
            });
            
            return Ok(result);
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequestDto loginRequestDto)
        {         
            var token = await _userService.GetUserByEmail(loginRequestDto);
            Response.Cookies.Append("tasty", token, new CookieOptions
            {
                HttpOnly = true,
                Secure = true,
                SameSite = SameSiteMode.Strict,
                Expires = DateTime.UtcNow.AddHours(12)
            });

            return Ok(new { token, message = "Вход выполнен успешно" });
        }
    }
}
