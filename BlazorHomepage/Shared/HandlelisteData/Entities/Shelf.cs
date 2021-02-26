using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorHomepage.Shared.Data.Entities
{
    [FirestoreData]
    public class Shelf
    {
        [FirestoreProperty]
        public int Id { get; set; }
        [FirestoreProperty]
        public string Name { get; set; }
        [FirestoreProperty]
        public ICollection<ItemCategory> ItemCateogries { get; set; }
        [FirestoreProperty]
        public ICollection<ShopItem> ItemsInShelf { get; set; }
        [FirestoreProperty]

        public int SortIndex { get; set; } //for å konfigurere en butikk



    }
}
