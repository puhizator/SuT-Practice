﻿using System.Text.Json.Serialization;

namespace DBTesting.REST.Models
{
    internal class User
    {
        public string City { get; set; }
        public string Country { get; set; }
        public string Email { get; set; }

        [JsonPropertyName("first_name")]
        public string FirstName { get; set; }
        public int Id { get; set; }

        [JsonPropertyName("is_admin")]
        public int IsAdmin { get; set; }
        public string Password { get; set; }

        [JsonPropertyName("sir_name")]
        public string SirName { get; set; }
        public string Title { get; set; }
    }
}
