using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksMarket.Db.Models
{
    public class Cover
    {
        public Guid Id { get; set; }

        public CoverType CoverType { get; set; }
    }
}
