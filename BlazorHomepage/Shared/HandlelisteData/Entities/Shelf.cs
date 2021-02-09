using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorHomepage.Shared.Data.Entities
{
    public class Shelf
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<ItemCategory> ItemCateogries { get; set; }
        public ICollection<ShopItem> ItemsInShelf { get; set; }

        public int SortIndex { get; set; } //for å konfigurere en butikk



    }
}
