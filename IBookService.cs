using BooksMarket.Db.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BooksMarket
{
    public interface IBookService
    {
        Task<IEnumerable<Book>> GetBooks(Filter filter);

        Book CreateBook(Book book);

        Task<Book> EditBook(Book book);
    }
}