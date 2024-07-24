using System.ComponentModel.DataAnnotations;

namespace TestPractice.Models
{
    public class User
    {

        [Key]
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string EmailId { get; set; }
        public int PhoneNumber { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string ConfirmPassword { get; set; }

        [Required]
        public string Role { get; set; }

       // public UserRole UserRole { get; set; }
    }
}
