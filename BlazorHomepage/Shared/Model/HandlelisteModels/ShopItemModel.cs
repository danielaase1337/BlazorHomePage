using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorHomepage.Shared.Model.HandlelisteModels
{
    public class ShopItemModel
    {

        public string Name { get; set; }
        public string Unit { get; set; } = "stk";
        public ItemCategoryModel ItemCategory { get; set; } = new ItemCategoryModel(); 

    }
}
