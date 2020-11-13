using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BooksMarket.Controllers.Api;
using BooksMarket.Db.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Annotations;

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

        [Route("get")]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Book>), 200)]
        [ProducesResponseType(500)]        
        public IActionResult Get([FromQuery] Filter filter)
        {
            var books =  _bookService.GetBooks(filter);
            return Ok(books);
        }

        [Route("create")]
        [HttpPost]
        [ProducesResponseType(typeof(Book), 200)]
        [ProducesResponseType(500)]
        public IActionResult Create([FromBody] BookDto book)
        {
            try
            {
                var result = _bookService.CreateBook(book);
                return Ok(result);
            }
            catch (BadRequestException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("editBook")]
        [HttpPut]
        [ProducesResponseType(typeof(Book), 200)]
        [ProducesResponseType(500)]
        public IActionResult EditBook([FromQuery]Guid id, [FromBody] EditBookDto bookDto)
        { 
            try
            {
                var result = _bookService.EditBook(id, bookDto);
                return Ok(result);
            }
            catch (BadRequestException ex)
            {
                return BadRequest(ex.Message);
            }            
        }

        [Route("editAutor")]
        [HttpPut]
        [ProducesResponseType(typeof(Autor), 200)]
        [ProducesResponseType(500)]
        public IActionResult EditAutor([FromQuery] Guid id, [FromBody] AutorDto autorDto)
        {
            try
            {
                var result = _bookService.EditAutor(id, autorDto);
                return Ok(result);
            }
            catch (BadRequestException ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
