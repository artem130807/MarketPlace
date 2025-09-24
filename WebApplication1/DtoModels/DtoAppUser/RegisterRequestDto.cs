namespace WebApplication1.DtoModels.DtoAppUser
{
    public class RegisterRequestDto
    {
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }

    }
}
