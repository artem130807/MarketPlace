namespace WebApplication1.Models
{
    public class Publishers
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Books> Books { get; set; }
    }
}
