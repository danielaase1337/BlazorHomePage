using BlazorHomepage.Shared.DataManagerModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorHomepage.Shared.HandlelisteData
{
    public interface IStorageContext 
    {
        ICollection<T> GetStoredItems<T>(T typeToGet) where T :class;
        T Add<T>(T contact) where T: class;
        bool Delete<T>(T contact) where T: class;
        T Update<T>(T updatedContact) where T : class;

        abstract void OnInitiliazing();
    }
    

}
