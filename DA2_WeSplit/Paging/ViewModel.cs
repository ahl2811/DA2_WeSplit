using DA2_WeSplit.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA2_WeSplit.Paging
{
    class TripViewModel
    {
        const int ITEMS_PER_PAGE = 9;
        public List<ChuyenDi> TripList { get; set; }
        public PagingInfo PagingInfo { get; set; }

        public TripViewModel(List<ChuyenDi>tripList)
        {
            TripList = tripList;
            int count = TripList.Count;
            PagingInfo = new PagingInfo(ITEMS_PER_PAGE, count);
        }

        public TripViewModel() { }
    }

}
