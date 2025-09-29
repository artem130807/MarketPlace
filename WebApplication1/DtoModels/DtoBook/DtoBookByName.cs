using WebApplication1.DtoModels.DtoAuthor;
using WebApplication1.DtoModels.DtoPublishers;

namespace WebApplication1.DtoModels.DtoBook
{
    public class DtoBookByName
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ISBN { get; set; }
        public decimal Price { get; set; }
        public DateTime YearPublished { get; set; } = DateTime.Now;
        public string CoverImageUrl { get; set; }
        public int StockQuantity { get; set; }
        public DtoAuthorShortInfo Author { get; set; }
        public DtoPublisherShortInfo Publisher { get; set; }
    }
}
