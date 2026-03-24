using LayeredRepo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LayeredRepo.Repositories
{
    internal interface IStudentRepository
    {
        void AddStudent(Student student);
        List<Student> GetAllStudents();
        Student GetStudentById(int id);
        void UpdateStudent(Student student);
        void DeleteStudent(int id);

    }
}
