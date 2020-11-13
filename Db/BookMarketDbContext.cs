using BooksMarket.Db.Models;
using Microsoft.EntityFrameworkCore;

namespace BooksMarket.Db
{
    public class BookMarketDbContext : DbContext
    {
        public BookMarketDbContext(DbContextOptions<BookMarketDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Book> Book{ get; set; }

        public DbSet<Autor> Autor { get; set; }

        public DbSet<Category> Category { get; set; }

        public DbSet<Genre> Genre { get; set; }

        public DbSet<Cover> Cover { get; set; }
    }
}
