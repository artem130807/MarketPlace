using WebApplication1.DtoModels.DtoBook;

namespace WebApplication1.DtoModels.DtoAuthor
{
    public class DtoAuthorsResponce
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Bio { get; set; }
        public List<DtoBookShortInfo> Books { get; set; }
    }
}
