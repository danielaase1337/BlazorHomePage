using BlazorHomepage.Shared.Data.Entities;
using BlazorHomepage.Shared.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorHomepage.Shared.Model.HandlelisteModels
{
    public class ShelfModel: EntityBase
    {
        public ICollection<ItemCategoryModel> ItemCateogries { get; set; } = new List<ItemCategoryModel>(); 
        public int SortIndex { get; set; } //for å konfigurere en butikk
    }
}
