using Microsoft.AspNetCore.Mvc;
using W18.Models;
using W18.Services.StudentService;

namespace W18.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentsController(IStudentService studentService)
        {
            _studentService = studentService;
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            var students = _studentService.GetAllStudents();
            return Ok(students);
        }


        [HttpPut("{id}")]
        public IActionResult Update(int id, Student student)
        {
            var updatedStudent = _studentService.UpdateStudent(id, student); 

            if (updatedStudent == null)
            {
                return NotFound("Student not found"); 
            }

            return Ok(updatedStudent); 
        }


        [HttpPost]
        public IActionResult Create(Student student)
        {
            var newStudent = _studentService.CreateStudent(student);
            return Ok(newStudent);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            bool isDeleted = _studentService.DeleteStudent(id);

            if (!isDeleted)
            {
                return NotFound("Student not found");
            }

            return Ok("Deleted successfully");
        }

        [HttpGet("count")]
        public IActionResult GetCount()
        {
            var count = _studentService.GetStudentCount();
            return Ok(new { count });
        }

    }
}