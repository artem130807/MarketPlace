using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace WebApplication1.Models
{
    public class CartItems
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public int BookId {  get; set; }
        public Books Book { get; set; }
        public Guid UserId { get; set; }
        public AppUsers User { get; set; }
    }
}
