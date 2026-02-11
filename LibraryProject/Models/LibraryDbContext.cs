using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace LibraryProject.Models;

public partial class LibraryDbContext : DbContext
{
    public LibraryDbContext()
    {
    }

    public LibraryDbContext(DbContextOptions<LibraryDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Author> Authors { get; set; }

    public virtual DbSet<Book> Books { get; set; }

    public virtual DbSet<BookLoan> BookLoans { get; set; }

    public virtual DbSet<Genre> Genres { get; set; }

    public virtual DbSet<Publisher> Publishers { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Status> Statuses { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=library_db;Username=postgres;Password=1111");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Author>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("authors_pkey");

            entity.ToTable("authors");

            entity.HasIndex(e => e.AuthorName, "authors_author_name_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AuthorName).HasColumnName("author_name");
        });

        modelBuilder.Entity<Book>(entity =>
        {
            entity.HasKey(e => e.Isbn).HasName("books_pkey");

            entity.ToTable("books");

            entity.Property(e => e.Isbn).HasColumnName("isbn");
            entity.Property(e => e.Annotation).HasColumnName("annotation");
            entity.Property(e => e.AvailableCopies).HasColumnName("available_copies");
            entity.Property(e => e.BookName).HasColumnName("book_name");
            entity.Property(e => e.CountPages).HasColumnName("count_pages");
            entity.Property(e => e.IdAuthor).HasColumnName("id_author");
            entity.Property(e => e.IdGenre).HasColumnName("id_genre");
            entity.Property(e => e.IdPublisher).HasColumnName("id_publisher");
            entity.Property(e => e.Picture).HasColumnName("picture");
            entity.Property(e => e.TotalCopies).HasColumnName("total_copies");
            entity.Property(e => e.YearPublication).HasColumnName("year_publication");

            entity.HasOne(d => d.Author).WithMany(p => p.Books)
                .HasForeignKey(d => d.IdAuthor)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("books_id_author_fkey");

            entity.HasOne(d => d.Genre).WithMany(p => p.Books)
                .HasForeignKey(d => d.IdGenre)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("books_id_genre_fkey");

            entity.HasOne(d => d.Publisher).WithMany(p => p.Books)
                .HasForeignKey(d => d.IdPublisher)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("books_id_publisher_fkey");
        });

        modelBuilder.Entity<BookLoan>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("book_loans_pkey");

            entity.ToTable("book_loans");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DateFact).HasColumnName("date_fact");
            entity.Property(e => e.DateIssue).HasColumnName("date_issue");
            entity.Property(e => e.DatePlan).HasColumnName("date_plan");
            entity.Property(e => e.IdBook).HasColumnName("id_book");
            entity.Property(e => e.IdStatus).HasColumnName("id_status");
            entity.Property(e => e.IdUser).HasColumnName("id_user");

            entity.HasOne(d => d.Book).WithMany(p => p.BookLoans)
                .HasForeignKey(d => d.IdBook)
                .HasConstraintName("book_loans_id_book_fkey");

            entity.HasOne(d => d.Status).WithMany(p => p.BookLoans)
                .HasForeignKey(d => d.IdStatus)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("book_loans_id_status_fkey");

            entity.HasOne(d => d.User).WithMany(p => p.BookLoans)
                .HasForeignKey(d => d.IdUser)
                .HasConstraintName("book_loans_id_user_fkey");
        });

        modelBuilder.Entity<Genre>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("genres_pkey");

            entity.ToTable("genres");

            entity.HasIndex(e => e.GenreName, "genres_genre_name_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.GenreName).HasColumnName("genre_name");
        });

        modelBuilder.Entity<Publisher>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("publishers_pkey");

            entity.ToTable("publishers");

            entity.HasIndex(e => e.PublisherName, "publishers_publisher_name_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.PublisherName).HasColumnName("publisher_name");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("roles_pkey");

            entity.ToTable("roles");

            entity.HasIndex(e => e.RoleName, "roles_role_name_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.RoleName).HasColumnName("role_name");
        });

        modelBuilder.Entity<Status>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("statuses_pkey");

            entity.ToTable("statuses");

            entity.HasIndex(e => e.StatusName, "statuses_status_name_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.StatusName).HasColumnName("status_name");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Ticket).HasName("users_pkey");

            entity.ToTable("users");

            entity.HasIndex(e => e.Login, "users_login_key").IsUnique();

            entity.Property(e => e.Ticket).HasColumnName("ticket");
            entity.Property(e => e.FullName).HasColumnName("full_name");
            entity.Property(e => e.IdRole).HasColumnName("id_role");
            entity.Property(e => e.Login).HasColumnName("login");
            entity.Property(e => e.PasswordHash).HasColumnName("password_hash");

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.IdRole)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("users_id_role_fkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
