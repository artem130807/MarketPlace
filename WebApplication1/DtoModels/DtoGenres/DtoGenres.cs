using WebApplication1.Models;

namespace WebApplication1.DtoModels.DtoGenres
{
    public class DtoGenres
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<BookGenres> GenresBook { get; set; }
    }
}
