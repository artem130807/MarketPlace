using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication1.Models;

namespace WebApplication1.Configurations
{
    public class OrderItemsConfigurations : IEntityTypeConfiguration<OrderItems>
    {
        public void Configure(EntityTypeBuilder<OrderItems> builder)
        {
            builder.ToTable("OrderItems");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Quantity);
            builder.Property(t => t.UnitPrice);
            builder.HasOne(t => t.Orders)
            .WithMany(t => t.Items)
            .HasForeignKey(t => t.OrderId);

            builder.HasOne(t => t.Book) 
            .WithMany()          
            .HasForeignKey(t => t.BookId);
        }
    }
}
