using Microsoft.EntityFrameworkCore;
using W18.Data;
using W18.Models;
using System.Collections.Generic;
using System.Linq;

namespace W18.Repositories.StudentRepository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly AppDbContext _context;

        public StudentRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Student> GetAll()
        {
            return _context.Students.ToList();
        }

        public int GetCount()
        {
            return _context.Students.Count();
        }


        public Student Create(Student student)
        {
            // This line is the "magic fix" for PostgreSQL
            student.DateOfBirth = DateTime.SpecifyKind(student.DateOfBirth, DateTimeKind.Utc);

            _context.Students.Add(student);
            _context.SaveChanges(); // The error was happening exactly here
            return student;
        }


        public Student? Update(int id, Student? updatedStudent)
        {
            var existing = _context.Students.Find(id);
            if (existing == null) return null;
            if (updatedStudent == null) return null;

            existing.FirstName = updatedStudent.FirstName;
            existing.LastName = updatedStudent.LastName;
            existing.DateOfBirth = updatedStudent.DateOfBirth;
            existing.Phone = updatedStudent.Phone;
            existing.Email = updatedStudent.Email;

            _context.SaveChanges(); 
            return existing;        
        }

        public bool Delete(int id)
        {
            var student = _context.Students.Find(id); 
            if (student == null) return false;       

            _context.Students.Remove(student);
            _context.SaveChanges();            
            return true;                       
        }
    }
}