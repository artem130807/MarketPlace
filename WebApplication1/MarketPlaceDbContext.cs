using Microsoft.EntityFrameworkCore;
using WebApplication1.Configurations;
using WebApplication1.Models;

namespace WebApplication1
{
    public class MarketPlaceDbContext:DbContext
    {
        public DbSet<AppUsers>  Users { get; set; }
        public DbSet<Authors> Authors { get; set; }
        public DbSet<Books> Books { get; set; }
        public DbSet<BookGenres> BookGenres { get; set; }
        public DbSet<Genres> Genres { get; set; }
        public DbSet<CartItems> CartItems { get; set; }
        public DbSet<Publishers> Publishers { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<OrderItems> OrderItems { get; set; }
        public DbSet<Reviews> Reviews { get; set; }

        public MarketPlaceDbContext(DbContextOptions<MarketPlaceDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {           
            modelBuilder.ApplyConfiguration(new AppUsersConfigurations());
            modelBuilder.ApplyConfiguration(new AuthorsConfigurations());
            modelBuilder.ApplyConfiguration(new BookGenresConfigurations());
            modelBuilder.ApplyConfiguration(new BooksConfigurations());
            modelBuilder.ApplyConfiguration(new CartItemsConfigurations());
            modelBuilder.ApplyConfiguration(new GenresConfigurations());
            modelBuilder.ApplyConfiguration(new OrderItemsConfigurations());
            modelBuilder.ApplyConfiguration(new OrdersConfigurations());
            modelBuilder.ApplyConfiguration(new PublishersConfigurations());
            modelBuilder.ApplyConfiguration(new ReviewsConfigurations());
            base.OnModelCreating(modelBuilder);
        }
    }
}
