using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksMarket.Db.Models
{
    public class Genre
    {
        public Guid Id { get; set; }

        public GenreType GenreType { get; set; }
    }
}
