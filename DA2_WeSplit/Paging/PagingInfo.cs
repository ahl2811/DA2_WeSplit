using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA2_WeSplit.Paging
{
    class PagingInfo
    {
        public int CurrentPage { get; set; }
        public int TotalPage { get; set; }
        public int RowsPerPage { get; set; }

        public PagingInfo(int rowsPerpage, int total)
        {
            CurrentPage = 1;
            RowsPerPage = rowsPerpage;
            TotalPage = total / rowsPerpage +
                ((total % rowsPerpage) == 0 ? 0 : 1);
        }
    }
}
