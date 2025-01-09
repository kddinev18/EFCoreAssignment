namespace EFCoreAssignment.DTOs
{
    public class AuthorDTO
    {
        public int AuthorId { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public int BirthYear { get; set; }
        public int? DeathYear { get; set; }
    }
}