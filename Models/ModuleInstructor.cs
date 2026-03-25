using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;

namespace W18.Models
{
    public class ModuleInstructor
    {
        [ForeignKey("Module")]
        public int ModuleId { get; set; }

        [ForeignKey("Instructor")]
        public int InstructorId { get; set; }

        public Module Module { get; set; } = null!;
        public Instructor Instructor { get; set; } = null!;
    }
}
