using BooksMarket.Controllers.Api;
using BooksMarket.Db;
using BooksMarket.Db.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksMarket
{
    public class BookService : IBookService
    {
        private readonly BookMarketDbContext _context;
   
        public BookService(BookMarketDbContext context)
        {
          _context = context;
        }

        #region create methods
        public Book CreateBook(BookDto bookDto)
        {
            var autor = new Autor();

            if (bookDto.AutorId == null)
            {
                autor.Id = Guid.NewGuid();
                autor.FirstName = bookDto.FirstName;
                autor.LastName = bookDto.LastName;
                autor.MiddleName = bookDto.MiddleName;
            }
            else
                autor = GetAutor(bookDto.AutorId.Value);

            var category = GetCategory(bookDto.Category);

            var cover = GetCover(bookDto.Cover);

            var genre = GetGenre(bookDto.Genre);

            var book = new Book()
            {
                Id = Guid.NewGuid(),
                Autor = autor,
                Category = category,
                Cover = cover,
                Genre = genre,
                Title = bookDto.Title 
            };            
            _context.Book.Add(book);
            _context.SaveChanges();

            return _context.Book
                .Include(b => b.Autor)
                .Include(b => b.Category)
                .Include(b => b.Cover)
                .Include(b => b.Genre)
                .First(b => b.Id == book.Id);
        }
        #endregion

        #region Get Methods
        private Genre GetGenre(GenreType genreType)
        {
            return _context.Genre.First(c => c.GenreType == genreType);
        }

        private Cover GetCover(CoverType coverType)
        {
            return _context.Cover.First(c => c.CoverType == coverType);
        }        

        public Book GetBook(Guid id)
        {
            var book = _context.Book.FirstOrDefault(c => c.Id == id);
            if (book == null)
                throw new BadRequestException($"book with {id} doesn't exist");
            return book;
        }

        public Category GetCategory(CategoryType categoryType)
        {
            return _context.Category.First(c => c.CategoryType == categoryType);
        }

        public IEnumerable<Book> GetBooks(Filter filter)
        {
            var query = _context.Book
                .Include(b => b.Autor)
                .Include(b => b.Category)
                .Include(b => b.Cover)
                .Include(b => b.Genre)
                .AsQueryable();

            if (filter.Title != null)
                query = _context.Book.Where(x => x.Title.Contains(filter.Title));

            if (filter.FirstName != null)
                query = _context.Book.Where(x => x.Autor.FirstName.Equals(filter.FirstName));

            if (filter.LastName != null)
                query = _context.Book.Where(x => x.Autor.LastName.Equals(filter.LastName));

            if (filter.MiddleName != null)
                query = _context.Book.Where(x => x.Autor.MiddleName.Equals(filter.MiddleName));

            if (filter.Category.HasValue)
                query = _context.Book.Where(x => x.Category.CategoryType == filter.Category);

            if (filter.Cover.HasValue)
                query = _context.Book.Where(x => x.Cover.CoverType == filter.Cover);

            if (filter.Genre.HasValue)
                query = _context.Book.Where(x => x.Genre.GenreType == filter.Genre);

            return query.ToList();
        }

        public Autor GetAutor(Guid id)
        {
            var autor = _context.Autor.FirstOrDefault(c => c.Id == id);
            if (autor == null)
                throw new BadRequestException($"autor with {id} doesn't exist");
            return autor;
        }
        #endregion

        #region Edit Methods
        public Book EditBook(Guid id, EditBookDto editBookDto)
        {
            var book = GetBook(id);
            if (editBookDto.AutorId.HasValue)
            {
                var autor = GetAutor(editBookDto.AutorId.Value);
                book.Autor = autor;
            }

            if (editBookDto.Category.HasValue)
            {
                var category = GetCategory(editBookDto.Category.Value);
                book.Category = category;
            }

            if (editBookDto.Cover.HasValue)
            {
                var cover = GetCover(editBookDto.Cover.Value);
                book.Cover = cover;
            }

            if (editBookDto.Genre.HasValue)
            {
                var genre = GetGenre(editBookDto.Genre.Value);
                book.Genre = genre;
            }
           
            _context.Book.Update(book);
            _context.SaveChanges();

            return _context.Book
                .Include(b => b.Autor)
                .Include(b => b.Category)
                .Include(b => b.Cover)
                .Include(b => b.Genre)
                .First(b => b.Id == book.Id);
        }

        public Autor EditAutor(Guid id, AutorDto autorDto)
        {
            var autor = GetAutor(id);
            autor.LastName = autorDto.LastName;
            autor.FirstName = autorDto.FirstName;
            autor.MiddleName = autorDto.MiddleName;

            _context.Autor.Update(autor);
            _context.SaveChanges();

            return _context.Autor.First(x => x.Id == autor.Id);
        }
        #endregion
    }
}
