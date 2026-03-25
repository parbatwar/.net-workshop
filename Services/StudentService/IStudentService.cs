using W18.Models;
using System.Collections.Generic;

namespace W18.Services.StudentService
{
    public interface IStudentService
    {
        IEnumerable<Student> GetAllStudents();

        int GetStudentCount();

        Student CreateStudent(Student student);

        Student? UpdateStudent(int id, Student student);

        bool DeleteStudent(int id);
    }
}