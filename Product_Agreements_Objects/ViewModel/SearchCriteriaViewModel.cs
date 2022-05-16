using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product_Agreements.ViewModel
{
    public class SearchCriteriaViewModel
    {
        public string SortColumn { get; set; }
        public string SortOrder { get; set; }
        public int OffSetValue { get; set; }
        public int PagingSize { get; set; }
        public string SearchText { get; set; }
        
    }
}
