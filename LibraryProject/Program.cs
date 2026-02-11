using System;
using System.Windows.Forms;
using LibraryProject.Models;
using Microsoft.EntityFrameworkCore.Query;

namespace LibraryProject
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            bool exitProgram = false;

            while (!exitProgram)
            {
                exitProgram = RunLoginAndMenu();
            }
        }

        static bool RunLoginAndMenu()
        {
            using (var formLogin = new FormLogin())
            {
                if (formLogin.ShowDialog() == DialogResult.OK)
                {
                    return formLogin.IsGuest
                        ? ShowBooksForGuest(formLogin.CurrentUser)
                        : ShowMenuForUser(formLogin.CurrentUser);
                }
                return true; // Если отменили авторизацию - выходим
            }
        }

        static bool ShowBooksForGuest(User guest)
        {
            using (var formBooks = new FormBooks(guest, true))
            {
                var result = formBooks.ShowDialog();
                return result != DialogResult.Abort; // Если не "Назад", то выходим
            }
        }

        static bool ShowMenuForUser(User user)
        {
            bool exitProgram = false;

            while (!exitProgram)
            {
                using (var formMenu = new FormMenu(user, false))
                {
                    switch (formMenu.ShowDialog())
                    {
                        case DialogResult.Yes: // Книги
                            exitProgram = ShowBooksForUser(user);
                            break;
                        case DialogResult.No: // /Выдачи
                            exitProgram = ShowLoansForUser(user);
                            break;
                        default: // Выход
                            return true;
                    }
                }
            }

            return exitProgram;
        }

        static bool ShowBooksForUser(User user)
        {
            using (var formBooks = new FormBooks(user, false))
            {
                return formBooks.ShowDialog() != DialogResult.Abort;
            }
        }

        static bool ShowLoansForUser(User user)
        {
            using (var formLoans = new FormLoans(user, false))
            {
                return formLoans.ShowDialog() != DialogResult.Abort;
            }
        }
    }
}