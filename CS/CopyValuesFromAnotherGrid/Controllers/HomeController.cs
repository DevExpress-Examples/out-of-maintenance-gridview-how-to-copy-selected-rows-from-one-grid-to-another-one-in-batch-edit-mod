using CopyValuesFromAnotherGrid.Models;
using DevExpress.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CopyValuesFromAnotherGrid.Controllers {
    public class HomeController : Controller {
        // GET: Home
        public ActionResult Index() {
            Session.Clear();
            return View();
        }

        [ValidateInput(false)]
        public ActionResult PredefinedItemsGridPartial() {
            var model = ItemRepository.GetPredefinedItems();
            return PartialView("_PredefinedItemsGridPartial", model);
        }

        [ValidateInput(false)]
        public ActionResult GridViewOrderListPartial() {
            var model = ItemRepository.Data;
            return PartialView("_GridViewOrderListPartial", model);
        }

        [ValidateInput(false), HttpPost]
        public ActionResult GridViewOrderListBatchUpdate(MVCxGridViewBatchUpdateValues<Item, object> updateValues) {
            var model = ItemRepository.Data;
            // Insert all added values. 
            var newId = model.Count > 0 ? model.Max(i => i.ItemID): 0;
            foreach (var item in updateValues.Insert) {
                try {
                    model.Add(new Item { ItemID = ++newId, ItemName = item.ItemName, ItemDescription = item.ItemDescription });
                } catch (Exception e) {
                    updateValues.SetErrorText(item, e.Message);
                }
            }
            // Update all edited values. 
            foreach (var item in updateValues.Update) {
                try {
                    var modelItem = model.FirstOrDefault(it => it.ItemID == item.ItemID);
                    if (modelItem != null) {
                        this.UpdateModel(modelItem);
                    }
                } catch (Exception e) {
                    updateValues.SetErrorText(item, e.Message);
                }
            }
            // Delete all values that were deleted on the client side from the data source. 
            foreach (var ItemID in updateValues.DeleteKeys) {
                try {
                    var item = model.FirstOrDefault(it => it.ItemID == Convert.ToInt32(ItemID));
                    if (item != null) model.Remove(item);
                } catch (Exception e) {
                    updateValues.SetErrorText(ItemID, e.Message);
                }
            }
            return PartialView("_GridViewOrderListPartial", model.ToList());
        }
    }
}