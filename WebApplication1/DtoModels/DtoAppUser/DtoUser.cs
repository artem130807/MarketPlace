using WebApplication1.Models;

namespace WebApplication1.DtoModels.DtoAppUser
{
    public class DtoUser
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public ICollection<Orders> Orders { get; set; }
        public ICollection<Reviews> Reviews { get; set; }
        public ICollection<CartItems> CartItems { get; set; }
    }
}
