using BlazorHomepage.Shared.CovidHandlerData;
using BlazorHomepage.Shared.CovidHandlerData.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorHomepage.Client.DataManagers
{
    public class CovidContactStorageContext : ICovidStorageContext<OneCovidContact>
    {
        private int _nextId;
        public CovidContactStorageContext()
        {
            OnInitiliazing();
        }

        public ICollection<OneCovidContact> Contacts { get; set; }


        public void OnInitiliazing()
        {
            if (Contacts == null || !Contacts.Any())
            {
                Contacts = new List<OneCovidContact>
                {
                    new OneCovidContact() { Id = 1, Name = "Emilie", CategoryId = "Nærkontakt", ContactDate = new DateTime(2021, 01, 30), OwnerId = "daniel", Sted = "Hjemme" },
                    new OneCovidContact() { Id = 2, Name = "Greger", CategoryId = "Nærkontakt", ContactDate = new DateTime(2021, 01, 20), OwnerId = "daniel", Sted = "Hjemme" },
                    new OneCovidContact() { Id = 3, Name = "Una", CategoryId = "Nærkontakt", ContactDate = new DateTime(2021, 01, 25), OwnerId = "daniel", Sted = "Hjemme" },
                    new OneCovidContact() { Id = 4, Name = "Ukjent", CategoryId = "Kontakt", ContactDate = new DateTime(2021, 01, 28), OwnerId = "emilie", Sted = "Butikken" }
                };
                _nextId = Contacts.Last().Id + 1;
            }
        }

        public T Add<T>(T entity) where T : class
        {
            if(entity is OneCovidContact contact)
            {
                contact.Id = _nextId;
                _nextId += 1;
                Contacts.Add(contact);
                return contact as T;
            }
            return null; 
        }

        public bool Delete<T>(T entity) where T : class
        {
            if(entity is OneCovidContact contact)
            {
                if (Contacts.Contains(contact))
                {
                    Contacts.Remove(contact);
                    return true;
                }
            }
            return false;
        }

        public T Update<T>(T entity ) where T : class
        {
            if(entity is OneCovidContact updatedContact)
            {
                var exisiting = Contacts.FirstOrDefault(f => f.Id == updatedContact.Id);
                if (exisiting != null)
                    exisiting = updatedContact;
                return exisiting as T;
            }
            return null;
        }
        
    }
}
