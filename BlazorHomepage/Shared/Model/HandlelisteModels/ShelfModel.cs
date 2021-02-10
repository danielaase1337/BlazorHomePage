using BlazorHomepage.Shared.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorHomepage.Shared.Model.HandlelisteModels
{
    public class ShelfModel
    {
        public string Name { get; set; }
        public ICollection<ItemCategoryModel> ItemCateogries { get; set; }
        public ICollection<ShopItemModel> ItemsInShelf { get; set; }
        public int SortIndex { get; set; } //for å konfigurere en butikk
    }
}
