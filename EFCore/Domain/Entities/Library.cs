namespace EFCoreAssignment.Domain.Models
{
    public class Library
    {
        public int LibraryId { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public int EstablishedYear { get; set; }

        public ICollection<BorrowRecord> BorrowRecords { get; set; }
    }
}