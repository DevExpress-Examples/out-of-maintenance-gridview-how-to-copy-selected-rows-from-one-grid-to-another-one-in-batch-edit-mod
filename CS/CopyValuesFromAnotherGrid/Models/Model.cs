using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CopyValuesFromAnotherGrid.Models {
    public class Item {
        public int ItemID { get; set; }
        public string ItemName { get; set; }
        public string ItemDescription { get; set; }
    }

    public static class ItemRepository {

        private static string sessionKey = "ItemsDataSource";
        public static List<Item> Data {
            get {
                if (HttpContext.Current.Session[sessionKey] == null)
                    HttpContext.Current.Session[sessionKey] = new List<Item>();

                return HttpContext.Current.Session[sessionKey] as List<Item>;
            }
            set { }
        }

        public static List<Item> GetPredefinedItems() {
            return new List<Item> {
                new Item { ItemID = 0, ItemName = "Pen", ItemDescription = "A set of 5 pens." },
                new Item { ItemID = 1, ItemName = "Pencil", ItemDescription = "A set of 5 pencils." },
                new Item { ItemID = 2, ItemName = "Paper", ItemDescription = "A pack of paper." }
            };
        }
    }
}