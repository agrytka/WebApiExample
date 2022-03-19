using Microsoft.EntityFrameworkCore;

namespace WebApplication2.Entities
{
    public class LibraryContext : DbContext
    {
        private string connectionString = @"Server=(localdb)\MSSQLLocalDB;Database=Library;Integrated Security=true;";

        //definiujemy tabele
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Author { get; set; }

        //dodajemy połączenia między tabelami
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
                .HasOne<Author>(m => m.Author)
                .WithMany(d => d.Books);

            modelBuilder.Entity<Author>()
                .HasMany(m => m.Books)
                .WithOne(m => m.Author);
        }

        //definiujemy połączenie do bazy danych
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }

    }
}
