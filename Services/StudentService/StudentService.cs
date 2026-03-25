using W18.Models;
using W18.Repositories.StudentRepository;
using System.Collections.Generic;

namespace W18.Services.StudentService
{

    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;

        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public IEnumerable<Student> GetAllStudents()
        {
            return _studentRepository.GetAll();
        }

        public int GetStudentCount()
        {
            return _studentRepository.GetCount();
        }

        public Student CreateStudent(Student student)
        {
            return _studentRepository.Create(student);
        }

        public Student? UpdateStudent(int id, Student student)
        {

            return _studentRepository.Update(id, student);
        }

        public bool DeleteStudent(int id)
        {
            return _studentRepository.Delete(id);
        }
    }
}