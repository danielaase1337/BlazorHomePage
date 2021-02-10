using BlazorHomepage.Shared.DataManagerModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorHomepage.Shared.HandlelisteData
{
    public interface IShoppingListStorageContext<T> : IStorageBase<T> where T: class
    {
        
        ICollection<T> StoredShoppingLists { get; set; }


    }
}
