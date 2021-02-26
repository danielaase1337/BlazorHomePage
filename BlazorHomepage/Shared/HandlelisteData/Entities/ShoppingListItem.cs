using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorHomepage.Shared.Data.Entities
{
    [FirestoreData]
    public class ShoppingListItem
    {
        [FirestoreProperty]
        public ShopItem Varen { get; set; }
        [FirestoreProperty]
        public int Mengde { get; set; }
        [FirestoreProperty]
        public bool IsDone { get; set; }

    }
}
