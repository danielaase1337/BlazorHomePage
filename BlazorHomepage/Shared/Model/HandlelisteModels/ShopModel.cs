using BlazorHomepage.Shared.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorHomepage.Shared.Model.HandlelisteModels
{
    public class ShopModel : EntityBase
    {
        public ICollection<ShelfModel> ShelfsInShop { get; set; }
        public SortedList<int, ShelfModel> SortedShelf { get; set; }

       
    }
}
