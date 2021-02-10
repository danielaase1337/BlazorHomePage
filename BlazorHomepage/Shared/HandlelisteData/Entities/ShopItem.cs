using System;
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

    }
}
