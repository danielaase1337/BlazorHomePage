using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorHomepage.Shared.Model.HandlelisteModels
{
    public class ShoppingListModel
    {
        public int ListId { get; set; } //public available.. 
        public string Name { get; set; }
        public ICollection<ShoppingListItemModel> ShoppingItems { get; set; }
        public bool IsDone { get; set; }
    }
}
