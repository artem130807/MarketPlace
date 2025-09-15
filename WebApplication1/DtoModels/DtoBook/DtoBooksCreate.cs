namespace WebApplication1.DtoModels.DtoBook
{
    public class DtoBooksCreate
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string ISBN { get; set; }
        public DateTime YearPublished { get; set; } = DateTime.Now;
        public string CoverImageUrl { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        public int AuthorId { get; set; }
        public int PublisherId { get; set; }
    }
}
