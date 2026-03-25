using System.ComponentModel.DataAnnotations;

namespace W18.Models
{
    public class Instructor
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public required string FirstName { get; set; }

        [Required]
        public required string LastName { get; set; }

        [EmailAddress]
        public string? Email { get; set; }

        [Required]
        public DateTime HireDate { get; set; }

        public ICollection<ModuleInstructor> ModuleInstructors { get; set; } = new List<ModuleInstructor>();
    }
}
