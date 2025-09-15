using WebApplication1.DtoModels.DtoBook;
using WebApplication1.Models;

namespace WebApplication1.DtoModels.DtoAuthor
{
    public class DtoAuthors
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Bio { get; set; }
        public List<DtoBookShortInfo> Books { get; set; }
    }
}
