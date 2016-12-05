using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using Fubon_Test.Models;

namespace Fubon_Test.ViewModels
{
    public class SaleOrderViewModel
    {
        public SaleOrderSearchModel SearchParameter { get; set; }

        public IPagedList<SaleOrder> SaleOrders { get; set; }

        public List<SelectListItem> StoreSelectItem { get; set; }

        public List<SelectListItem> OrderStateSelectItem { get; set; }

        public int PageIndex { get; set; }
    }
}