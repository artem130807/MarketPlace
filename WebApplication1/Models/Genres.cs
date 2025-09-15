namespace WebApplication1.Models
{
    public class Genres
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<BookGenres> GenresBook { get; set; }
    }
}
