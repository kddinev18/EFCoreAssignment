using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace EFCoreAssignment.DTOs
{
    public class UserDTO
    {
        [JsonRequired]
        [MinLength(3)]
        public string FirstName { get; set; } = null!;

        [JsonRequired]
        [MinLength(3)]
        public string LastName { get; set; } = null!;

        [JsonRequired]
        [EmailAddress]
        public string Email { get; set; } = null!;
    }
}
