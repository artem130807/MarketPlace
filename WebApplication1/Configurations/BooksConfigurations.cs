using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication1.Models;

namespace WebApplication1.Configurations
{
    public class BooksConfigurations : IEntityTypeConfiguration<Books>
    {
        public void Configure(EntityTypeBuilder<Books> builder)
        {
            builder.ToTable("Books");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Title);
            builder.Property(t => t.Description);
            builder.Property(t => t.ISBN);
            builder.Property(t => t.Price);
            builder.Property(t => t.YearPublished);
            builder.Property(t => t.CoverImageUrl);
            builder.Property(t => t.StockQuantity);
            builder.HasOne(t => t.Author).WithMany(t => t.Books).HasForeignKey(t => t.AuthorId);
            builder.HasOne(t => t.Publisher).WithMany(t => t.Books).HasForeignKey(t => t.PublisherId);

            builder.HasMany(b => b.CartItems)
            .WithOne(ci => ci.Book)
            .HasForeignKey(ci => ci.BookId)
            .OnDelete(DeleteBehavior.Cascade); 

            builder.HasMany(b => b.Reviews)
                .WithOne(r => r.Books)
                .HasForeignKey(r => r.BookId)
                .OnDelete(DeleteBehavior.Cascade);
        }
        
    }
}
