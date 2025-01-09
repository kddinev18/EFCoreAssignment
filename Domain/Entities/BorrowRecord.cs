namespace EFCoreAssignment.Domain.Models
{
    public class BorrowRecord
    {
        public int BorrowRecordId { get; set; }
        public int BookId { get; set; }
        public int LibraryId { get; set; }
        public string BorrowerName { get; set; }
        public DateTime BorrowDate { get; set; }
        public DateTime? ReturnDate { get; set; }

        public Book Book { get; set; }
        public Library Library { get; set; }
    }
}