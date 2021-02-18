using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorHomepage.Shared.Data.Entities
{
    public class ShoppingList
    {
        public int ListId { get; set; }
        public string Name { get; set; }
        public ICollection<ShoppingListItem> ShoppingItems { get; set; }
        public bool IsDone { get; set; }

    }
}
