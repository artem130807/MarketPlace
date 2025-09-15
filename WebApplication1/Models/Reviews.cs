namespace WebApplication1.Models
{
    public class Reviews
    {
        public int Id { get; set; } 
        public int Rating { get; set; }
        public string Comment { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public Guid UserId { get; set; }
        public int BookId { get; set; }
        public AppUsers AppUsers { get; set; }
        public Books Books { get; set; }
    }
}
