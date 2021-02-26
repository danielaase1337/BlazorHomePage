using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorHomepage.Shared.Data.Entities
{
    [FirestoreData]
    public class ShopItem : FireStoreCommonBase
    {
        [FirestoreProperty]
        public string Id { get; set; }
        [FirestoreProperty]
        public string Name { get; set; }
        [FirestoreProperty]
        public string Unit { get; set; } //Stk, vekt osv.. 
        [FirestoreProperty]
        public ItemCategory ItemCategory { get; set; }

        public static List<ShopItem> GetDefault()
        {
            var res = new List<ShopItem>()
            {
                new ShopItem(){Id = "1", ItemCategory = new ItemCategory("Meieri", "1"), Name = "Melk", Unit = "Liter"},
                new ShopItem(){Id = "2", ItemCategory = new ItemCategory("Meieri", "1"), Name = "Smør", Unit = "stk"},
                new ShopItem(){Id = "3", ItemCategory = new ItemCategory("Brød", "1"), Name = "Brød", Unit = "stk"},
                new ShopItem(){Id = "4", ItemCategory = new ItemCategory("Drikke", "1"), Name = "Øl", Unit = "stk" }
            };

            return res;
        }
    }
}
