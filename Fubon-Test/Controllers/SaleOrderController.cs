using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Fubon_Test.Models;
using Fubon_Test.ViewModels;
using PagedList;
using Fubon_Test.Bussiness;

namespace Fubon_Test.Controllers
{
    public class SaleOrderController : Controller
    {
        private WECHATDBEntities db = new WECHATDBEntities();
        private int pageSize = 10;

        // GET: SaleOrder
        public ActionResult Index(int page = 1)
            
        {

            int pageIndex = page < 1 ? 1 : page;

            var source = db.SaleOrder.OrderBy(x => x.OrderNo);

            var model = new SaleOrderViewModel
            {
                SearchParameter = new SaleOrderSearchModel(),
                PageIndex = pageIndex,
                OrderStateSelectItem = HtmlValues.OrderStateSelectItem(),
                StoreSelectItem = HtmlValues.StoreSelectItem(),
                SaleOrders = source.ToPagedList(pageIndex, pageSize),
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(SaleOrderViewModel model)
        {
            int pageIndex = model.PageIndex < 1 ? 1 : model.PageIndex;


            System.Diagnostics.Debug.WriteLine(string.Format("startdate:{0}",model.SearchParameter.startDate));
            System.Diagnostics.Debug.WriteLine(string.Format("enddate:{0}",model.SearchParameter.endDate));
            System.Diagnostics.Debug.WriteLine(string.Format("refund:{0}",model.SearchParameter.refundState));
            System.Diagnostics.Debug.WriteLine(string.Format("check:{0}",model.SearchParameter.checkState));

            IEnumerable<SaleOrder> source = db.SaleOrder;

            if (!string.IsNullOrWhiteSpace(model.SearchParameter.storeId))
            {
                source = source.Where(x => x.StoreId.Equals(model.SearchParameter.storeId));
            }

            if (!string.IsNullOrWhiteSpace(model.SearchParameter.orderState))
            {
                source = source.Where(x => x.OrderState.Equals(Convert.ToInt16(model.SearchParameter.orderState)));
            }

            source = source.OrderBy(x => x.OrderNo);

            var result = new SaleOrderViewModel
            {
                SearchParameter = new SaleOrderSearchModel(),
                PageIndex = pageIndex,
                OrderStateSelectItem = HtmlValues.OrderStateSelectItem(),
                StoreSelectItem = HtmlValues.StoreSelectItem(),
                SaleOrders = source.ToPagedList(pageIndex, pageSize)
            };

            return View(result);
        }

        public ActionResult PartialViewTest()
        {

            return PartialView();
        }

    }
}