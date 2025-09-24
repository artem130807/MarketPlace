using WebApplication1.Auth;

namespace WebApplication1.Service.Hasher
{
    public class PasswordHasher:IHasherPassword
    {
        public string Generate(string password) => BCrypt.Net.BCrypt.EnhancedHashPassword(password);
        public bool Verify(string password, string hashedPassword) => BCrypt.Net.BCrypt.EnhancedVerify(password, hashedPassword);
    }
}
