namespace WebApplication1.DtoModels.DtoBook
{
    public class DtoBooksUpdate
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string ISBN { get; set; }
        public decimal Price { get; set; }
        public string CoverImageUrl { get; set; }
        public int StockQuantity { get; set; }
        public int AuthorId { get; set; }
        public int PublisherId { get; set; }
    }
}
