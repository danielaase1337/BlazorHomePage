using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorHomepage.Shared.Data.Entities
{
    public class Shop
    {
        public string Name { get; set; }
        public string Identificator { get; set; }
        public string Id { get; set; }
        public ICollection<Shelf> Shelfs { get; set; }

    }
}
