using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fubon_Test.ViewModels
{
    public class SaleOrderSearchModel
    {
        public string startDate { get; set; }
        public string endDate { get; set; }
        public string storeId { get; set; }
        public string orderState { get; set; }
        public int refundState { get; set; }
        public bool checkState { get; set; }

    }
}