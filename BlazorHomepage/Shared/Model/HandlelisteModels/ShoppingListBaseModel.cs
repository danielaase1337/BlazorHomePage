using BlazorHomepage.Shared.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorHomepage.Shared.Model.HandlelisteModels
{
    public class ShoppingListBaseModel: EntityBase
    {
        public bool IsDone { get; set; } = false;

        public new string CssComleteEditClassName
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

    }
}
