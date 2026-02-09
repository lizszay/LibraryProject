using LibraryProject.Models;
using LibraryProject.Properties;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LibraryProject
{
    public partial class FormBooks : Form
    {

        public User CurrentUser { get; private set; }
        public bool IsGuest { get; private set; }
        public FormBooks(User user, bool guest)
        {
            InitializeComponent();

            var colPhoto = new DataGridViewImageColumn();
            colPhoto.Name = "colPhoto";
            colPhoto.ImageLayout = DataGridViewImageCellLayout.Zoom;
            colPhoto.Width = 200;
            colPhoto.FillWeight = 30;

            var colInfo = new DataGridViewTextBoxColumn();
            colInfo.Name = "colInfo";
            colInfo.FillWeight = 60;
            colInfo.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            dgvBooks.Columns.AddRange(
            [
                colPhoto, colInfo
            ]);

            CurrentUser = user;
            IsGuest = guest;

            lblUserName.Text = IsGuest ? "Гость" : CurrentUser.FullName;

            LoadBooks();

            this.Load += (s, e) => dgvBooks.ClearSelection();
        }

        private void LoadBooks()
        {
            try
            {
                using (var db = new LibraryDbContext())
                {
                    var books = db.Books
                        .Include(i => i.Author)
                        .Include(i => i.Genre)
                        .Include(i => i.Publisher)
                        .ToList();

                    dgvBooks.SuspendLayout();
                    dgvBooks.Rows.Clear();

                    foreach (var book in books)
                    {
                        int rowIndex = dgvBooks.Rows.Add();
                        var row = dgvBooks.Rows[rowIndex];

                        row.Cells["colPhoto"].Value = LoadBooksImage(book.Picture);

                        row.Cells["colInfo"].Value = FormatBookInfo(book);

                        ApplyRowSryles(row, book);
                    }

                    dgvBooks.ResumeLayout();
                    dgvBooks.AutoResizeRows(DataGridViewAutoSizeRowsMode.AllCells);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Ошибка загрузки: {ex.Message}",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void ApplyRowSryles(DataGridViewRow row, Book book)
        {
            if (book.AvailableCopies == 0)
            {
                row.DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#FFCCCC");
            }
            else if (book.AvailableCopies >= 2)
            {
                row.DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#FFF3CD ");
            }
        }

        private object? FormatBookInfo(Book book)
        {
            return $"{book.Isbn} | {book.BookName}\n" +
                $"Автор: {book.Author}\n" +
                $"Жанр: {book.Genre}\n" +
                $"Издательство: {book.Publisher}\n" +
                $"Год издания: {book.YearPublication}\n" +
                $"Страниц: {book.CountPages}\n" +
                $"Всего экземпляров: {book.TotalCopies}\n" +
                $"Доступно экземпляров: {book.AvailableCopies}\n" +
                $"Аннотация: {book.Annotation}";
        }

        private Image LoadBooksImage(string picture)
        {
            if (!String.IsNullOrEmpty(picture) && System.IO.File.Exists(picture))
            {
                return Image.FromFile(picture);
            }

            return Resources.bookPlaceholder;
        }

        private void BtnLogout_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Abort;
            this.Close();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
        }
    }
}
