using BlazorHomepage.Shared.Model.GoogleModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorHomepage.Shared.Repository
{
    public class GoogleFireBaseItemCategoryDbContext : GoogleFireBaseDbContext
    {
        public GoogleFireBaseItemCategoryDbContext():base(new ItemCategoryCollectionModel())
        {

        }
    }

}
