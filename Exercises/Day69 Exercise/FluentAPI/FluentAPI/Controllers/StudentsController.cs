using FluentAPI.DTOs;
using FluentAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FluentAPI.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json", "application/xml")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public StudentsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var students = await _context.Students
        .Include(s => s.StudentCourses)
        .ThenInclude(sc => sc.Course)
        .Select(s => new StudentWithCoursesDto
        {
            Id = s.Id,
            Name = s.Name,
            Email = s.Email,
            Age = s.Age,
            Courses = s.StudentCourses.Select(sc => new CourseDto
            {
                Id = sc.Course.Id,
                Title = sc.Course.Title,
                Credits = sc.Course.Credits
            }).ToList()
        })
        .ToListAsync();

            return Ok(students);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            //var student = await _context.Students.FindAsync(id);
            var student = await _context.Students
        .Include(s => s.StudentCourses)       // Load join table
        .ThenInclude(sc => sc.Course)        // Load course details
        .FirstOrDefaultAsync(s => s.Id == id);
            if (student == null) return NotFound();

            //return Ok(student);
            var dto = new StudentWithCoursesDto
            {
                Id = student.Id,
                Name = student.Name,
                Email = student.Email,
                Age = student.Age,
                Courses = student.StudentCourses.Select(sc => new CourseDto
                {
                    Id = sc.Course.Id,
                    Title = sc.Course.Title,
                    Credits = sc.Course.Credits
                }).ToList()
            };

            return Ok(dto);
        }

        [HttpPost]
        public async Task<IActionResult> Create(StudentDto dto)
        {
            var student = new Student
            {
                Name = dto.Name,
                Email = dto.Email,
                Age = dto.Age
            };

            _context.Students.Add(student);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new { id = student.Id }, student);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, StudentDto dto)
        {
            var student = await _context.Students.FindAsync(id);
            if (student == null) return NotFound();

            student.Name = dto.Name;
            student.Email = dto.Email;
            student.Age = dto.Age;

            await _context.SaveChangesAsync();
            return Ok(student);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student == null) return NotFound();

            _context.Students.Remove(student);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
