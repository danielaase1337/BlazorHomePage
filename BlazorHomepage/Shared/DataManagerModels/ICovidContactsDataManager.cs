using BlazorHomepage.Shared.CovidHandlerData.Entities;
using BlazorHomepage.Shared.Model.CovidModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorHomepage.Shared.DataManagerModels
{
    public interface ICovidContactsDataManager
    {
        void Add<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class; 

        Task<bool> SaveChangesAsync(); 

        Task<List<OneContactModel>> GetAllContactsFromUser(string userId);
        Task<List<OneContactModel>> GetAllContactsFromUser(string userId, int nDays);
        Task<List<OneContactModel>> GetAllContactsFromUser(string userId, DateTime fromDate, DateTime toDate);

    }
}
