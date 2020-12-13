using DA2_WeSplit.Database;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA2_WeSplit.Paging
{
    class TripViewModel
    {
        const int ITEMS_PER_PAGE = 9;
        public ObservableCollection<ChuyenDi> TripList { get; set; }
        public PagingInfo PagingInfo { get; set; }

        public TripViewModel(ObservableCollection<ChuyenDi>tripList)
        {
            TripList = tripList;
            int count = TripList.Count;
            PagingInfo = new PagingInfo(ITEMS_PER_PAGE, count);
        }

        public TripViewModel() { }
    }

}
