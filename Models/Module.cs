using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace W18.Models
{
    public class Module
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public required string Title { get; set; }

        [Required]
        public int Credits { get; set; }

        [Required]
        public int CourseId { get; set; }
 
        [ForeignKey("CourseId")]
        public Course Course { get; set; } = null!;

        public ICollection<ModuleInstructor> ModuleInstructors { get; set; } = new List<ModuleInstructor>();
    }
}
