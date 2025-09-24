using Microsoft.EntityFrameworkCore;
using WebApplication1.Contracts.ContractsAppUser;
using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public class AppUserRepository : IUserRepository
    {
        private readonly MarketPlaceDbContext _marketPlaceDbContext;
        public AppUserRepository(MarketPlaceDbContext marketPlaceDbContext)
        {
            _marketPlaceDbContext = marketPlaceDbContext;
        }

        public async Task<AppUsers> CreateUser(AppUsers appUsers)
        {
            _marketPlaceDbContext.Users.Add(appUsers);
            await _marketPlaceDbContext.SaveChangesAsync();     
            return appUsers;
        }

        public async Task<AppUsers> GetUserByEmail(string email)
        {
            var user = await _marketPlaceDbContext.Users.FirstOrDefaultAsync(x => x.Email == email);
            if (user == null)
                throw new Exception("Пользователя не существует");
            return user;
        }
    }
}
