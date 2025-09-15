using Microsoft.AspNetCore.Identity;

namespace WebApplication1.Models
{
    public class AppUsers:IdentityUser<Guid>
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public ICollection<Orders> Orders { get; set; }
        public ICollection<Reviews> Reviews { get; set; }
        public ICollection<CartItems> CartItems { get; set; }
    }
}
