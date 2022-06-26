using BlazorHomepage.Shared.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorHomepage.Shared.Model.HandlelisteModels
{
    public class ShopItemModel : EntityBase
    {

        public string Unit { get; set; } = "stk";
        public ItemCategoryModel ItemCategory { get; set; } = new ItemCategoryModel();
        public override bool IsValid()
        {
            return !string.IsNullOrEmpty(Name)
                && ItemCategory.IsValid();
        }
    }
}
