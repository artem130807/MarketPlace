namespace WebApplication1.Models
{
    public class BookGenres
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public int GenreId { get; set; }
        public Books Book { get; set; }
        public Genres Genre { get; set; }
    }
}
