using System;
using System.Threading;

namespace BooksMarket.Db.Models
{
    public class Book
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public Autor Autor { get; set; }
                
        public Cover Cover { get; set; }

        public Category Category { get; set; }

        public Genre Genre { get; set; }
    }
}
