using AutoMapper;
using BlazorHomepage.Shared.CovidHandlerData;
using BlazorHomepage.Shared.CovidHandlerData.Entities;
using BlazorHomepage.Shared.DataManagerModels;
using BlazorHomepage.Shared.Model.CovidModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorHomepage.Client.DataManagers
{
    public class CovidContactsLocalDataManager : ICovidContactsDataManager
    {
        private readonly IMapper _mapper;
        private readonly ICovidStorageContext<OneCovidContact> _context;
        private int _nextId;
        public CovidContactsLocalDataManager(IMapper mapper, ICovidStorageContext<OneCovidContact> context)
        {
            _mapper = mapper;
            _context = context;
        }

        public void Add<T>(T entity) where T : class
        {
            try
            {
                if (entity is OneContactModel model)
                {
                    model.Id = _nextId;
                    _nextId += 1;
                    var covidContact = _mapper.Map<OneCovidContact>(model);
                    covidContact.OwnerId = model.Name.ToLower(); //finnes ikke på modell objektet.. just for testing.. 
                    _context.Add(covidContact);
                }

                //return contact;
            }
            catch (Exception e)
            {
                Debug.Write(e);
                //return null;
            }
        }


        public void Delete<T>(T entity) where T : class
        {
            _context.Delete(entity as OneCovidContact);
        }

        public async Task<List<OneContactModel>> GetAllContactsFromUser(string ownerId)
        {
            await Task.Delay(1);
            var res = _context.Contacts.Where(f => f.OwnerId.Equals(ownerId));
            if (res == null) return new List<OneContactModel>();
            var mappedObjects = _mapper.Map<OneContactModel[]>(res);
            return mappedObjects.ToList();
        }

        public async Task<List<OneContactModel>> GetAllContactsFromUser(string ownerId, int nDays)
        {
            await Task.Delay(1);

            var allfromUser = _context.Contacts.Where(f => f.OwnerId == ownerId).Where(a => (DateTime.Now - a.ContactDate).Days <= nDays);
            var mappedOBjects = _mapper.Map<OneContactModel[]>(allfromUser);
            return mappedOBjects.ToList();
        }

        public async Task<List<OneContactModel>> GetAllContactsFromUser(string userId, DateTime fromDate, DateTime toDate)
        {
            await Task.Delay(1);
            var res = _context.Contacts.Where(f => f.ContactDate < toDate && f.ContactDate > fromDate);
            var mapped = _mapper.Map<OneContactModel[]>(res);
            return mapped.ToList();
        }

        public async Task<bool> SaveChangesAsync()
        {
            await Task.Delay(1);
            var res = true;
            return res;
        }

        public void Update<T>(T entity) where T : class
        {
            if (entity is OneContactModel contact)
            {
                try
                {
                    var mappedContact = _mapper.Map<OneCovidContact>(contact);
                    var updated = _context.Update(mappedContact);
                }
                catch (Exception e)
                {
                    Debug.Write(e);

                }
            }
        }

    }
}
