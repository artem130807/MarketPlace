namespace WebApplication1.Auth
{
    public interface IHasherPassword
    {
        public string Generate(string password);
        public bool Verify(string password, string hashedPassword);
    }
}
