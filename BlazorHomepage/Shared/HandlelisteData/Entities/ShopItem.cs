﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorHomepage.Shared.Data.Entities
{
    public class ShopItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Unit { get; set; } //Stk, vekt osv.. 
        public bool Done { get; set; }

        public ItemCategory ItemCategory { get; set; }

        public static List<ShopItem> GetDefault()
        {
            var res = new List<ShopItem>()
            {
                new ShopItem(){Id = 1, ItemCategory = new ItemCategory("Meieri", 1), Name = "Melk", Unit = "Liter", Done = false },
                new ShopItem(){Id = 1, ItemCategory = new ItemCategory("Meieri", 1), Name = "Smør", Unit = "stk", Done = false },
                new ShopItem(){Id = 1, ItemCategory = new ItemCategory("Brød", 1), Name = "Brød", Unit = "stk", Done = false },
                new ShopItem(){Id = 1, ItemCategory = new ItemCategory("Drikke", 1), Name = "Øl", Unit = "stk", Done = false }
            };
            return res; 
        }
    }
}
