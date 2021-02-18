using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorHomepage.Shared.DataManagerModels
{
    public interface IStorageBase
    {
        T Add<T>(T contact) where T : class;
        bool Delete<T>(T contact) where T : class;
        T Update<T>(T updatedContact) where T :class;

        abstract void OnInitiliazing();
    }
}
