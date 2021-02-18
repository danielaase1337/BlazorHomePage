using BlazorHomepage.Shared.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorHomepage.Shared.DataManagerModels
{
    public interface IUserDataManager<T> : IStorageBase
    {
        Task<T[]> GetAllUsersAsync(); 
        Task<T> GetUsersAsync(string id);
    }
}
