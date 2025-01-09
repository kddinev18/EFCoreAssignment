public class SeedDataModel
{
    public List<AuthorDTO> Authors { get; set; }
    public List<BookDTO> Books { get; set; }
    public List<LibraryDTO> Libraries { get; set; }
    public List<BorrowRecordDTO> BorrowRecords { get; set; }
}

public class AuthorDTO
{
    public int AuthorId { get; set; }
    public string Name { get; set; }
    public string Country { get; set; }
    public int BirthYear { get; set; }
    public int DeathYear { get; set; }
}

public class BookDTO
{
    public int BookId { get; set; }
    public int AuthorId { get; set; }
    public string Title { get; set; }
    public string Genre { get; set; }
    public int PublicationYear { get; set; }
    public int CopiesAvailable { get; set; }
}

public class LibraryDTO
{
    public int LibraryId { get; set; }
    public string Name { get; set; }
    public string Location { get; set; }
    public int EstablishedYear { get; set; }
}

public class BorrowRecordDTO
{
    public int BorrowRecordId { get; set; }
    public int BookId { get; set; }
    public int LibraryId { get; set; }
    public string BorrowerName { get; set; }
    public string BorrowDate { get; set; }
    public string? ReturnDate { get; set; }
}

