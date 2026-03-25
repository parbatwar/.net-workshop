using System.ComponentModel.DataAnnotations;

namespace W18.Models
{
    public class Course
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public required string Name { get; set; }

        [Required]
        public int DurationYears { get; set; }

        public ICollection<Module> Modules { get; set; } = new List<Module>();

        public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
    }
}
