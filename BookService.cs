using BooksMarket.Db;
using BooksMarket.Db.Models;
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

        public Book CreateBook(Book book)
        {
            if (book.Id == Guid.Empty)
                book.Id = Guid.NewGuid();
            _context.Book.Add(book);
            _context.SaveChanges();

            return _context.Book.First(b => b.Id == book.Id);
        }

        public Task<Book> EditBook(Book book)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Book>> GetBooks(Filter filter)
        {
            throw new NotImplementedException();
        }
    }
}
