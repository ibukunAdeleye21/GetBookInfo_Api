using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookInfo.API.Entities
{
    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }

        [Required]
        [MaxLength(50)]
        public string UserName { get; set; }

        [Required]
        [MinLength(10)]
        public string Password { get; set; }

        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        [Required]
        [MaxLength(50)]
        public string Book { get; set; }

        // Constructor to make it easy to construct the user
        public User(
            string userName,
            string password,
            string firstName,
            string lastName,
            string book)
        {
            UserName = userName;
            FirstName = firstName;
            Password = password;
            LastName = lastName;
            Book = book;
        }
    }
}
