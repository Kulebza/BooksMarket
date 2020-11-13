using BooksMarket.Db.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksMarket.Controllers.Api
{
    public class Filter
    {
        public string Title { get; set; }

        public string LastName { get; set; }

        public string MiddleName { get; set; }

        public string FirstName { get; set; }

        public CoverType? Cover { get; set; }

        public CategoryType? Category { get; set; }

        public GenreType? Genre { get; set; }
    }
}
