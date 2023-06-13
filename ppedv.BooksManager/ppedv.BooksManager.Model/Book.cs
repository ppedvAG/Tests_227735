namespace ppedv.BooksManager.Model
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int Pages { get; set; }
        public DateTime PublishDate { get; set; }

        public ICollection<Author> Authors { get; set; } = new HashSet<Author>();
    }
}