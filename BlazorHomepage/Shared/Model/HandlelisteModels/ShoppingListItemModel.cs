using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorHomepage.Shared.Model.HandlelisteModels
{
    public class ShoppingListItemModel
    {
        public ShopItemModel Varen { get; set; }
        public int Mengde { get; set; }
        public bool IsDone { get; set; }
    }
}
