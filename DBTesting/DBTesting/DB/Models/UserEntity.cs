using System.ComponentModel.DataAnnotations.Schema;

namespace DBTesting.Models
{
    public class UserEntity
    {
        public int Id { get; set; }

        [Column("Is_Admin")]
        public bool IsAdmin { get; set; }

        [Column("First_Name")]
        public string FirstName { get; set; }

        [Column("Sir_Name")]
        public string SirName { get; set; }
        public string Title { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
