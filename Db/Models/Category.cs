using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksMarket.Db.Models
{
    public class Category
    {
        public Guid Id { get; set; }

        public CategoryType CategoryType { get; set; }
    }
}
