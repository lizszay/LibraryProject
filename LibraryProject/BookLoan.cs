using System;
using System.Collections.Generic;

namespace LibraryProject;

public partial class BookLoan
{
    public int Id { get; set; }

    public string? IdUser { get; set; }

    public string? IdBook { get; set; }

    public DateOnly DateIssue { get; set; }

    public DateOnly DatePlan { get; set; }

    public DateOnly? DateFact { get; set; }

    public int IdStatus { get; set; }

    public virtual Book? IdBookNavigation { get; set; }

    public virtual Status IdStatusNavigation { get; set; } = null!;

    public virtual User? IdUserNavigation { get; set; }
}
