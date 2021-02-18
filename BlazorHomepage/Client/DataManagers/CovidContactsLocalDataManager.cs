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
        public CovidContactsLocalDataManager(IMapper mapper, ICovidStorageContext<OneCovidContact> context)
        {
            _mapper = mapper;
            _context = context;
        }

        public T Add<T>(T entity) where T : class
        {
            try
            {
                if (entity is OneContactModel model)
                {
                    var covidContact = _mapper.Map<OneCovidContact>(model);
                    var res = _context.Add(covidContact);
                    model.Id = res.Id;
                    return model as T;
                }

                //return contact;
            }
            catch (Exception e)
            {
                Debug.Write(e);
                return null;
            }
            return null; 
        }


        public bool Delete<T>(T entity) where T : class
        {
            var res = _context.Delete(entity as OneCovidContact);
            return res; 
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

        public T Update<T>(T entity) where T : class
        {
            if (entity is OneContactModel contact)
            {
                try
                {
                    var mappedContact = _mapper.Map<OneCovidContact>(contact);
                    var updated = _context.Update(mappedContact);
                    var remap = _mapper.Map<OneContactModel>(updated);
                    return remap as T; 
                }
                catch (Exception e)
                {
                    Debug.Write(e);
                    return null; 
                }
            }
            return null; 
        }

    }
}
