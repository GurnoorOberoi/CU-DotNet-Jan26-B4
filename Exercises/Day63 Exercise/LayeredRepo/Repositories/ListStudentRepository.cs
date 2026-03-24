using LayeredRepo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LayeredRepo.Repositories
{
    internal class ListStudentRepository : IStudentRepository
    {
        private List<Student> students =  new List<Student>();
        public void AddStudent(Student student)
        {
            students.Add(student);
        }
        public List<Student> GetAllStudents()
        {
            return students;
        }
        public Student GetStudentById(int id)
        {
            return students.FirstOrDefault(s => s.Id == id);
        }
        public void UpdateStudent(Student student)
        {
            var existingStudent = GetStudentById(student.Id);
            if (existingStudent != null)
            {
                existingStudent.Name = student.Name;
                existingStudent.Grade = student.Grade;
            }
        }
        public void DeleteStudent(int id)
        {
            var student = GetStudentById(id);
            if (student != null)
            {
                students.Remove(student);
            }
        }
    }
}
