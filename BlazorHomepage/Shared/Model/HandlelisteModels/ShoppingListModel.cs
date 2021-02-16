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
        public ICollection<ShoppingListItemModel> ShoppingItems { get; set; } = new List<ShoppingListItemModel>();
        public bool IsDone { get; set; } = false;

        public string CssEditClassName
        {
            get
            {
                if (IsDone)
                    return "completed";
                else if (EditClicked)
                    return "edit";
                else return "";
            }
        }
        public bool EditClicked { get; set; }


    }
}
