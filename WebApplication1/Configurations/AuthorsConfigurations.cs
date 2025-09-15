using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication1.Models;

namespace WebApplication1.Configurations
{
    public class AuthorsConfigurations : IEntityTypeConfiguration<Authors>
    {
        public void Configure(EntityTypeBuilder<Authors> builder)
        {
            builder.ToTable("Authors");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.LastName);
            builder.Property(t => t.FirstName);
            builder.Property(t => t.Bio);
        }
    }
}
