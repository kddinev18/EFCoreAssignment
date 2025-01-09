using System.Text.Json.Serialization;

namespace EFCoreAssignment.DTOs
{
    public class UserDTO
    {
        [JsonRequired]
        public string FirstName { get; set; } = null!;

        [JsonRequired]
        public string LastName { get; set; } = null!;

        [JsonRequired]
        public string Email { get; set; } = null!;
    }
}
