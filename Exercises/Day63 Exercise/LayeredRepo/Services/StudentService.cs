using LayeredRepo.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LayeredRepo.Models;

namespace LayeredRepo.Services
{
    internal class StudentService 
    {
        private IStudentRepository _repository { get; set;  }
        public StudentService(IStudentRepository repository)
        {
            _repository = repository;
        }
        //IStudentRepository repository = new 
        public void AddStudent(Student student)
        {
            if(student.Grade<0 || student.Grade > 100)
            {
                throw new ArgumentException("Grade must be between 0 and 100.");
            }
            _repository.AddStudent(student);
        }
        public List<Student> GetAllStudents()
        {
            return _repository.GetAllStudents();
        }
        public void UpdateStudent(Student student)
        {
            if (student.Grade < 0 || student.Grade > 100)
            {
                throw new ArgumentException("Grade must be between 0 and 100.");
            }
            _repository.UpdateStudent(student);
        }
        public void DeleteStudent(int id)
        {
            _repository.DeleteStudent(id);
        }
    }
}
