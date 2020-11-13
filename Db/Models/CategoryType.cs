using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace BooksMarket.Db.Models
{
    public enum CategoryType
    {
        [Description("0 -3")] ZeroThree,
        [Description("3 - 10")] ThreeTen,
        [Description("10 - 15")] TenFifteen,
        [Description("15 - 17")] FifteenSeventeen,
        [Description("18+")] Adult
    }
}
