using System.Text.Json.Serialization;

namespace DBTesting.REST.Models
{
    internal class User
    {
        [JsonPropertyName("city")]
        public object City { get; set; }

        [JsonPropertyName("country")]
        public object Country { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("first_name")]
        public string FirstName { get; set; }

        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("is_admin")]
        public int IsAdmin { get; set; }

        [JsonPropertyName("password")]
        public string Password { get; set; }

        [JsonPropertyName("sir_name")]
        public string SirName { get; set; }

        [JsonPropertyName("title")]
        public object Title { get; set; }
    }
}
