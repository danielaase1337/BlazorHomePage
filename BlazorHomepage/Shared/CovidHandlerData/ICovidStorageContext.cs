using BlazorHomepage.Shared.CovidHandlerData.Entities;
using BlazorHomepage.Shared.DataManagerModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorHomepage.Shared.CovidHandlerData
{
    public interface ICovidStorageContext<T> : IStorageBase where T : class 
    {

        ICollection<T> Contacts { get; set; }

    }
}
