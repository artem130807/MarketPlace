using WebApplication1.DtoModels.DtoBook;

namespace WebApplication1.DtoModels.DtoPublishers
{
    public class DtoPublisher
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<DtoBookShortInfo> Book { get; set; }
    }
}
