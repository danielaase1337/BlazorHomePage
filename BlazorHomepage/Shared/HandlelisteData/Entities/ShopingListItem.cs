using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorHomepage.Shared.Data.Entities
{
    public class ShopingListItem
    {
        public int Id { get; set; }
        public ShopItem Varen { get; set; }
        public int Mengde { get; set; }
        public bool IsDone { get; set; }

    }
}
