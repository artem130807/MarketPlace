using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication1.Models;

namespace WebApplication1.Configurations
{
    public class AppUsersConfigurations : IEntityTypeConfiguration<AppUsers>
    {
        public void Configure(EntityTypeBuilder<AppUsers> builder)
        {
            builder.ToTable("Users");
            builder.HasKey(x => x.Id);
            
            builder.Property(t => t.LastName).HasMaxLength(50).IsRequired();
            builder.Property(t => t.FirstName).HasMaxLength(50).IsRequired();

            builder.Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(256);

            builder.HasIndex(u => u.Email)
               .IsUnique(); // Уникальный email

            builder.Property(u => u.PasswordHash)
                .IsRequired();
        }
    }
}
