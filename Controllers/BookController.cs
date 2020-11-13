using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BooksMarket.Db.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BooksMarket.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {            
            _bookService = bookService;
        }

        //возвращать код
        [Route("get")]
        [HttpGet]
        public async Task<IEnumerable<Book>> Get([FromQuery] Filter filter)
        {
            var books = await _bookService.GetBooks(filter);
            return books;
        }

        [Route("create")]
        [HttpPut]
        public Book Create([FromBody] Book book)
        {
            var result = _bookService.CreateBook(book);
            return result;
        }

        [Route("edit")]
        [HttpPost]
        public async Task<Book> Edit([FromBody] Book book)
        {
            var result = await _bookService.EditBook(book);
            return result;
        }

    }
}
