using System;
using System.Collections.Generic;

namespace LibraryProject;

public partial class Book
{
    public string Isbn { get; set; } = null!;

    public string BookName { get; set; } = null!;

    public int IdAuthor { get; set; }

    public int IdGenre { get; set; }

    public int IdPublisher { get; set; }

    public int YearPublication { get; set; }

    public int CountPages { get; set; }

    public int TotalCopies { get; set; }

    public int AvailableCopies { get; set; }

    public string Annotation { get; set; } = null!;

    public string? Picture { get; set; }

    public virtual ICollection<BookLoan> BookLoans { get; set; } = new List<BookLoan>();

    public virtual Author IdAuthorNavigation { get; set; } = null!;

    public virtual Genre IdGenreNavigation { get; set; } = null!;

    public virtual Publisher IdPublisherNavigation { get; set; } = null!;
}
