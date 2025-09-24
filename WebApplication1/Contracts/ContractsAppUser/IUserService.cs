using WebApplication1.DtoModels.DtoAppUser;
using WebApplication1.Models;

namespace WebApplication1.Contracts.ContractsAppUser
{
    public interface IUserService
    {
        public Task<AuthResponseDto> CreateUser(RegisterRequestDto dtoCreateUser);
        public Task<string> GetUserByEmail(LoginRequestDto loginRequestDto);
    }
}
