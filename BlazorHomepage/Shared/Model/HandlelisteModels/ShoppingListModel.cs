﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorHomepage.Shared.Model.HandlelisteModels
{
    public class ShoppingListModel : ShoppingListBaseModel
    {
        public ICollection<ShoppingListItemModel> ShoppingItems { get; set; } = new List<ShoppingListItemModel>();
    }
}
