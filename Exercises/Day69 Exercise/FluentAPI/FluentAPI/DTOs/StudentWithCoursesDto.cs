namespace FluentAPI.DTOs
{
    public class StudentWithCoursesDto
    {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Email { get; set; }
            public int Age { get; set; }
            public List<CourseDto> Courses { get; set; } = new List<CourseDto>();
    }
}
