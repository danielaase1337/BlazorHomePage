using BlazorHomepage.Shared.DataManagerModels;
using BlazorHomepage.Shared.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorHomepage.Client.DataManagers
{
    public class CovidContactsLocalDataManager : ICovidContactsDataManager
    {
        private int _nextId;
        private List<OneCovidContact> _privateTempData = new List<OneCovidContact>();
        public CovidContactsLocalDataManager()
        {
            _privateTempData.Add(new OneCovidContact() { Id = 1, Name = "Emilie", CategoryId = "Nærkontakt", ContactDate = new DateTime(2021, 01, 30), OwnerId = "daniel", Sted = "Hjemme" });
            _privateTempData.Add(new OneCovidContact() { Id = 2, Name = "Greger", CategoryId = "Nærkontakt", ContactDate = new DateTime(2021, 01, 20), OwnerId = "daniel", Sted = "Hjemme" });
            _privateTempData.Add(new OneCovidContact() { Id = 3, Name = "Una", CategoryId = "Nærkontakt", ContactDate = new DateTime(2021, 01, 25), OwnerId = "daniel", Sted = "Hjemme" });
            _privateTempData.Add(new OneCovidContact() { Id = 4, Name = "Ukjent", CategoryId = "Kontakt", ContactDate = new DateTime(2021, 01, 28), OwnerId = "emilie", Sted = "Butikken" });
            _nextId = _privateTempData.Last().Id + 1;
        }


        public async Task<OneCovidContact> AddContact(OneCovidContact contact)
        {
            try
            {
                await Task.Delay(1);
                contact.Id = _nextId;
                _nextId += 1;

                _privateTempData.Add(contact);
                return contact;
            }
            catch (Exception e)
            {
                Debug.Write(e); 
                return null;
            }

        }

        public async Task DeleteContact(int id)
        {
            await Task.Delay(1);
            var toDelete = _privateTempData.Where(f => f.Id == id);
            if (toDelete != null)
                foreach (var item in toDelete)
                {
                    _privateTempData.Remove(item);

                }
        }

        public async Task<List<OneCovidContact>> GetAllContactsFromUser(string ownerId)
        {
            await Task.Delay(1);

            return _privateTempData.Where(f => f.OwnerId.Equals(ownerId))?.ToList() ?? new List<OneCovidContact>();
        }

        public async Task<List<OneCovidContact>> GetAllContactsFromUser(string ownerId, int nDays)
        {
            await Task.Delay(1);

            var allfromUser = _privateTempData.Where(f => f.OwnerId == ownerId).Where(a => (DateTime.Now - a.ContactDate).Days <= nDays);
            return allfromUser.ToList();
        }

        public async Task<List<OneCovidContact>> GetAllContactsFromUser(string userId, DateTime fromDate, DateTime toDate)
        {
            await Task.Delay(1);

            var res = _privateTempData.Where(f => f.ContactDate < toDate && f.ContactDate > fromDate);
            return res.ToList();
        }

        public async Task<OneCovidContact> UpdateContact(OneCovidContact contact)
        {
            await Task.Delay(1);
            try
            {
                var existing = _privateTempData.FirstOrDefault(f => f.Id == contact.Id);
                if (existing != null)
                    existing = contact;
                return contact;
            }
            catch (Exception e)
            {
                Debug.Write(e);
                return null;
            }
        }
    }
}
