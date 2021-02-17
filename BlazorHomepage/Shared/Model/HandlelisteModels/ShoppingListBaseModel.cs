using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorHomepage.Shared.Model.HandlelisteModels
{
    public class ShoppingListBaseModel
    {
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
