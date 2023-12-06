using Microsoft.EntityFrameworkCore;
using MsWebFinalNW.Models;

    namespace MsWebFinalNW.Data
    {
        public class DbContextApp : DbContext
        {
            public DbContextApp(DbContextOptions<DbContextApp> options) : base(options)
            {
            }
            public DbSet<Book> Books { get; set; }
            public DbSet<Author> Authors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                modelBuilder.Entity<Author>().HasData(
                    new Author { AuthorId = 1, Name = "J.K. Rowling" },
                    new Author { AuthorId = 2, Name = "S.E. Hinton" }
                );

                modelBuilder.Entity<Book>().HasData(
                    new Book { BookId = 1, Title = "Harry Potter and the Chamber of Secrets", AuthorId = 1 },
                    new Book { BookId = 2, Title = "The Outsiders", AuthorId = 2 }
                    );

            modelBuilder.Entity<Book>()
            .HasOne(b => b.Author)
            .WithMany(a => a.Books)
            .HasForeignKey(b => b.AuthorId);
        }
        }
    }