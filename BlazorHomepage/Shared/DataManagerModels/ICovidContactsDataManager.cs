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
        List<OneCovidContact> GetAllContactsFromUser(string userId);
        List<OneCovidContact> GetAllContactsFromUser(string userId, int nDays);
        List<OneCovidContact> GetAllContactsFromUser(string userId, DateTime fromDate, DateTime toDate);

        void UpdateContact(OneCovidContact contact);
        void AddContact(OneCovidContact contact);
        void DeleteContact(int id);

    }
}
