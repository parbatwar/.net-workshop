using W18.Models;
using System.Collections.Generic;

namespace W18.Repositories.StudentRepository
{

    public interface IStudentRepository
    {
        IEnumerable<Student> GetAll();

        int GetCount();

        Student Create(Student student);

        Student? Update(int id, Student student);

        bool Delete(int id);
    }
}