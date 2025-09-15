namespace WebApplication1.Models
{
    public class Books
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ISBN { get; set; }
        public decimal Price { get; set; }
        public DateTime YearPublished { get; set; } = DateTime.Now;
        public string CoverImageUrl { get; set; }
        public int StockQuantity { get; set; }
        public Authors Author { get; set; }
        public Publishers Publisher { get; set; }
        public ICollection<BookGenres> Genres { get; set; }
        public ICollection<CartItems> CartItems { get; set; }
        public ICollection<OrderItems> OrderItems { get; set; }
        public ICollection<Reviews> Reviews { get; set; }
        public int AuthorId {  get; set; }
        public int PublisherId { get; set; }

    }
}
