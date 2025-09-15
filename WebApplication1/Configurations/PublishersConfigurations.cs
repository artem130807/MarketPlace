using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication1.Models;

namespace WebApplication1.Configurations
{
    public class PublishersConfigurations : IEntityTypeConfiguration<Publishers>
    {
        public void Configure(EntityTypeBuilder<Publishers> builder)
        {
            builder.ToTable("Publishers");
            builder.HasKey(x => x.Id);
            builder.Property(t => t.Name);
            
        }
    }
}
