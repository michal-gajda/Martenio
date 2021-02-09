namespace Martenio.WebApi.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.Text.Json.Serialization;

    public sealed record User
    {
        [Required]
        [JsonPropertyName("firstName")]
        public string FirstName { get; init; } = string.Empty;
        [JsonPropertyName("middleName")]
        public string? MiddleName { get; init; } = null;
        [Required]
        [JsonPropertyName("lastName")]
        public string LastName { get; init; } = string.Empty;
    }
}
