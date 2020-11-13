using BooksMarket.Db.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.Threading;

namespace BooksMarket.Controllers.Api
{
    public class EditBookDto
    {        
        public Guid? AutorId { get; set; }
                
        public string Title { get; set; }

        public CoverType? Cover { get; set; }

        public CategoryType? Category { get; set; }

        public GenreType? Genre { get; set; }
    }
}
