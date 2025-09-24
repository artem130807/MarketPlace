using WebApplication1.Models;

namespace WebApplication1.Provider
{
    public interface IJwtProvider
    {
        public string GenerateToken(AppUsers appUsers);
    }
}
