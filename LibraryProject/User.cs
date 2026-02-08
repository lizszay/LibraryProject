using System;
using System.Collections.Generic;

namespace LibraryProject;

public partial class User
{
    public int IdRole { get; set; }

    public string FullName { get; set; } = null!;

    public string Ticket { get; set; } = null!;

    public string Login { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public virtual ICollection<BookLoan> BookLoans { get; set; } = new List<BookLoan>();

    public virtual Role IdRoleNavigation { get; set; } = null!;
}
