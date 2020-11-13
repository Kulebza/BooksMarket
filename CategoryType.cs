using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace BooksMarket
{
    public enum CategoryType
    {
        [Description("0 -3")] ZeroThree,
        [Description("3 - 10")] ThreeTen,
        [Description("18+")] Adult
    }
}
