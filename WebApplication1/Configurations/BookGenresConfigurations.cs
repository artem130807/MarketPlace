using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication1.Models;

namespace WebApplication1.Configurations
{
    public class BookGenresConfigurations : IEntityTypeConfiguration<BookGenres>
    {
        public void Configure(EntityTypeBuilder<BookGenres> builder)
        {
            builder.ToTable("BookGenres");
            builder.HasKey(bg => new { bg.BookId, bg.GenreId });
            builder.HasOne(t => t.Book).WithMany(t => t.Genres).HasForeignKey(t => t.BookId).OnDelete(DeleteBehavior.ClientNoAction); ; 
            builder.HasOne(t => t.Genre).WithMany(t => t.GenresBook).HasForeignKey(t => t.GenreId).OnDelete(DeleteBehavior.ClientNoAction); ;
        }
    }
}
