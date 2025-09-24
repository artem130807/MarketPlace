using WebApplication1.DtoModels.DtoAppUser;
using WebApplication1.Models;

namespace WebApplication1.Contracts.ContractsAppUser
{
    public interface IUserRepository
    {
        public Task<AppUsers> CreateUser(AppUsers appUsers);
        public Task<AppUsers> GetUserByEmail(string email);
    }
}
