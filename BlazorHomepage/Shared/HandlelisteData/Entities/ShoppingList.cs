using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorHomepage.Shared.Data.Entities
{
    [FirestoreData]
    public class ShoppingList: FireStoreCommonBase
    {
        [FirestoreProperty]
        public string ListId { get; set; }
        [FirestoreProperty] 
        public string Name { get; set; }
        [FirestoreProperty] 
        public ICollection<ShoppingListItem> ShoppingItems { get; set; }
        [FirestoreProperty] 
        public bool IsDone { get; set; }
    }
}
