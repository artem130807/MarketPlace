using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication1.Models;

namespace WebApplication1.Configurations
{
    public class CartItemsConfigurations : IEntityTypeConfiguration<CartItems>
    {
        public void Configure(EntityTypeBuilder<CartItems> builder)
        {
            builder.ToTable("CartItems");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Quantity);
            builder.HasOne(t => t.User).WithMany(t => t.CartItems).HasForeignKey(t => t.UserId).OnDelete(DeleteBehavior.ClientNoAction); ;
            builder.HasOne(t => t.Book).WithMany(t => t.CartItems).HasForeignKey(t => t.BookId).OnDelete(DeleteBehavior.ClientNoAction); ;
        }
    }
}
