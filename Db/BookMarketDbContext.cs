using BooksMarket.Db.Models;
using Microsoft.EntityFrameworkCore;
using System;

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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.Id).IsRequired();
                entity.Property(e => e.CategoryType).IsRequired();
                entity.HasIndex(u => u.CategoryType).IsUnique();
            });
            
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = Guid.NewGuid(), CategoryType = CategoryType.ZeroThree },
                new Category { Id = Guid.NewGuid(), CategoryType = CategoryType.ThreeTen },
                new Category { Id = Guid.NewGuid(), CategoryType = CategoryType.TenFifteen },
                new Category { Id = Guid.NewGuid(), CategoryType = CategoryType.FifteenSeventeen },
                new Category { Id = Guid.NewGuid(), CategoryType = CategoryType.Adult });

            modelBuilder.Entity<Cover>(entity =>
            {
                entity.Property(e => e.Id).IsRequired();
                entity.Property(e => e.CoverType).IsRequired();
                entity.HasIndex(u => u.CoverType).IsUnique();
            });

            modelBuilder.Entity<Cover>().HasData(
                new Cover { Id = Guid.NewGuid(), CoverType = CoverType.Soft },
                new Cover { Id = Guid.NewGuid(), CoverType = CoverType.Hard },
                new Cover { Id = Guid.NewGuid(), CoverType = CoverType.Handmade });

            modelBuilder.Entity<Genre>(entity =>
            {
                entity.Property(e => e.Id).IsRequired();
                entity.Property(e => e.GenreType).IsRequired();
                entity.HasIndex(u => u.GenreType).IsUnique();
            });

            modelBuilder.Entity<Genre>().HasData(
                new Genre { Id = Guid.NewGuid(), GenreType = GenreType.Detective },
                new Genre { Id = Guid.NewGuid(), GenreType = GenreType.Novel },
                new Genre { Id = Guid.NewGuid(), GenreType = GenreType.Poetry },
                new Genre { Id = Guid.NewGuid(), GenreType = GenreType.PopSience });            
        }
    }
}
