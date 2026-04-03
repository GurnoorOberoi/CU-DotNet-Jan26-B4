namespace DBFirstSerilog.DTOs
{
    public class CreateBookDto
    {
        public string Title { get; set; }
        public string Genre { get; set; }
        public int? PublishedYear { get; set; }
        public int? AuthorId { get; set; }
    }
}
