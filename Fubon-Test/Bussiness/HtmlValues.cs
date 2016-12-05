using Fubon_Test.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Fubon_Test.Bussiness
{
    public class HtmlValues
    {
        private static WECHATDBEntities db = new WECHATDBEntities();


        public static List<SelectListItem> OrderStateSelectItem()
        {
            var listselectitem = new List<SelectListItem>();
            foreach (OrderState state in Enum.GetValues(typeof(OrderState)))
            {
                listselectitem.Add(new SelectListItem()
                {
                    Text = state.ToString(),
                    Value = Convert.ToString((int)state),
                });

                Console.WriteLine("{0}-{1}", state, (int)state);
            }
            return listselectitem;
        }


        private List<SelectListItem> GetSelectList(IEnumerable<string> source,string selectedItem)
        {
            var selectList = source.Select(item => new SelectListItem()
            {
                Text = item,
                Value = item,
                Selected = !string.IsNullOrWhiteSpace(selectedItem)
                           &&
                           item.Equals(selectedItem, StringComparison.OrdinalIgnoreCase)
            });
            return selectList.ToList();
        }


        public static List<SelectListItem> StoreSelectItem()
        {
            var listselectitem = new List<SelectListItem>();

            foreach (var store in db.Store.ToList())
            {
                listselectitem.Add(new SelectListItem()
                {
                    Text = store.StoreName,
                    Value = store.StoreId,
                });
            }
            return listselectitem;
        }


    }
}