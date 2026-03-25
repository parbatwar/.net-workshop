using System.ComponentModel.DataAnnotations;

namespace W18.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public required string FirstName { get; set; }

        [Required]
        public required string LastName { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        public string? Phone { get; set; }

        [EmailAddress]
        public string? Email { get; set; }

    }
}   