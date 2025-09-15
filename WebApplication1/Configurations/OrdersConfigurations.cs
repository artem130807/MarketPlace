using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication1.Models;

namespace WebApplication1.Configurations
{
    public class OrdersConfigurations : IEntityTypeConfiguration<Orders>
    {
        public void Configure(EntityTypeBuilder<Orders> builder)
        {
            builder.ToTable("Orders");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.OrderDate);
            builder.Property(t => t.TotalSum).HasColumnType("decimal(18,2)"); 
            builder.Property(t => t.Status);
            builder.Property(t => t.ShippingAddress);
            builder.HasOne(t => t.AppUsers).WithMany(t => t.Orders).HasForeignKey(t => t.UserId);
        }
    }
}
