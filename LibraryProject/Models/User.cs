using System;
using System.Collections.Generic;

namespace LibraryProject.Models;

public partial class User
{
    public int IdRole { get; set; }

    public string FullName { get; set; } = null!;

    public string Ticket { get; set; } = null!;

    public string Login { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public virtual ICollection<BookLoan> BookLoans { get; set; } = new List<BookLoan>();

    public virtual Role Role { get; set; } = null!;
}
