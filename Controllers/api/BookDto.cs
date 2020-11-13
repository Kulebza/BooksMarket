using BooksMarket.Db.Models;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.ComponentModel.DataAnnotations;
using System.Threading;

namespace BooksMarket.Controllers.Api
{
    public class BookDto
    {
        [SwaggerSchema("Autor Id if autor already exist in database")]
        public Guid? AutorId { get; set; }

        [Required]
        public string Title { get; set; }

        [SwaggerSchema("Autor FirstName if autor doesn't exist in database")]
        public string FirstName { get; set; }

        [SwaggerSchema("Autor LastName if autor doesn't exist in database")]
        public string LastName { get; set; }

        [SwaggerSchema("Autor MiddleName if autor doesn't exist in database")]
        public string MiddleName { get; set; }

        [Required]
        public CoverType Cover { get; set; }

        [Required]
        public CategoryType Category { get; set; }

        [Required]
        public GenreType Genre { get; set; }
    }
}
