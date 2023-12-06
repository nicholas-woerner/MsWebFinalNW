namespace MsWebFinalNW.Models
{
    public class Author
    {
        public string Name { get; set; }
        public int AuthorId { get; set; }
        public ICollection<Book> Books { get; set; }

    }
}   
