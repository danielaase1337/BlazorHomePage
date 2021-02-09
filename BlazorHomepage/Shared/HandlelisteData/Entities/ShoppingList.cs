using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorHomepage.Shared.Data.Entities
{
    public class ShoppingList
    {
        public int DbId { get; set; }
        public string ListId { get; set; } //public available.. 
        public string Name { get; set; }
        public ICollection<ShopingListItem> ShoppingItems { get; set; }
        public bool IsDone { get; set; }

    }
}
