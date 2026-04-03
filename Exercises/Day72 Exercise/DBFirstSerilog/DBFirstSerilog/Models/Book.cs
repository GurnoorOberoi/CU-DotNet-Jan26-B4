using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DBFirstSerilog.Models;

public partial class Book
{
    public int BookId { get; set; }

    public string Title { get; set; } = null!;

    public string? Genre { get; set; }

    public int? PublishedYear { get; set; }

    public int? AuthorId { get; set; }

    [ForeignKey("AuthorId")]
    public virtual Author Author { get; set; }
}
