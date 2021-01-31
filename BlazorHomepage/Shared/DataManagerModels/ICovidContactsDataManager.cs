using BlazorHomepage.Shared.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorHomepage.Shared.DataManagerModels
{
    public interface ICovidContactsDataManager
    {
        Task<List<OneCovidContact>> GetAllContactsFromUser(string userId);
        Task<List<OneCovidContact>> GetAllContactsFromUser(string userId, int nDays);
        Task<List<OneCovidContact>> GetAllContactsFromUser(string userId, DateTime fromDate, DateTime toDate);

        Task<OneCovidContact> UpdateContact(OneCovidContact contact);
        Task<OneCovidContact> AddContact(OneCovidContact contact);
        Task DeleteContact(int id);

    }
}
