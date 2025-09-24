using WebApplication1.DtoModels.DtoAuthor;
using WebApplication1.DtoModels.DtoPublishers;
using WebApplication1.Models;

namespace WebApplication1.ModelsFiltr
{
    public class BooksQueryParametr
    {
        public string? Title { get; set; }       
        public decimal? MinPrice { get; set; } 
        public decimal? MaxPrice { get; set; } 
        //public string? SortBy { get; set; }
        //public bool SortDescending { get; set; }
        public string? AuthorLastName { get; set; }
        public string? PublisherName { get; set; }
    }
}
