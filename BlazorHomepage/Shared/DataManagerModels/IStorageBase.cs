using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorHomepage.Shared.DataManagerModels
{
    public interface IStorageBase<T>
    {
        T Add(T contact);
        bool Delete(T contact);
        T Update(T updatedContact);

        abstract void OnInitiliazing();
    }
}
