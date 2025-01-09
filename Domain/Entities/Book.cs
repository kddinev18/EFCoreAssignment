namespace EFCoreAssignment.Domain.Models
{
    public class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public int PublicationYear { get; set; }
        public int CopiesAvailable { get; set; }

        public int AuthorId { get; set; }
        
        public Author Author { get; set; }
    }
}