using System;
using System.Collections.Generic;

namespace Library.Data.Models;

public partial class Book
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public int? AuthorId { get; set; }

    public string? Genre { get; set; }

    public int? PublishedYear { get; set; }

    public virtual Author? Author { get; set; }
}
