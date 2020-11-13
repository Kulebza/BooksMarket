using BooksMarket.Controllers.Api;
using BooksMarket.Db.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BooksMarket
{
    public interface IBookService
    {
        IEnumerable<Book> GetBooks(Filter filter);

        Book CreateBook(BookDto book);

        Book EditBook(Guid id, EditBookDto bookDto);

        Autor EditAutor(Guid id, AutorDto autorDto);
    }
}