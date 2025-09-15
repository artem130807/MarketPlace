using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication1.Models;

namespace WebApplication1.Configurations
{
    public class ReviewsConfigurations : IEntityTypeConfiguration<Reviews>
    {
        public void Configure(EntityTypeBuilder<Reviews> builder)
        {
            builder.ToTable("Reviews");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Rating);
            builder.Property(x => x.Comment);
            builder.Property(x => x.CreatedDate);
            builder.HasOne(x => x.AppUsers).WithMany(x => x.Reviews).HasForeignKey(x => x.UserId);
            builder.HasOne(x => x.Books).WithMany(x => x.Reviews).HasForeignKey(x => x.BookId).OnDelete(DeleteBehavior.ClientNoAction); ;
        }
    }
}
