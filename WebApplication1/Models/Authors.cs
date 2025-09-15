namespace WebApplication1.Models
{
    public class Authors
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Bio { get; set; }
        public ICollection<Books> Books { get; set; }
    }
}
