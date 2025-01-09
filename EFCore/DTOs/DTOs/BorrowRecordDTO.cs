namespace EFCoreAssignment.DTOs
{
    public class BorrowRecordDTO
    {
        public int BorrowRecordId { get; set; }
        public int BookId { get; set; }
        public int LibraryId { get; set; }
        public string BorrowerName { get; set; }
        public DateTime BorrowDate { get; set; }
        public DateTime? ReturnDate { get; set; }
    }
}