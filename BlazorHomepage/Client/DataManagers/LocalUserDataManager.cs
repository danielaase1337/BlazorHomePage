using BlazorHomepage.Shared.DataManagerModels;
using BlazorHomepage.Shared.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorHomepage.Client.DataManagers
{
    public class LocalUserDataManager : IUserDataManager
    {
        private List<User> _localUsers;
        private int _nextUserId; 
        public LocalUserDataManager()
        {
            _localUsers = new List<User>()
            {
                new User(){FirstName = "Daniel", LastName = "Aase", EMail = "aase.daniel@gmail.com", UserName = "supergnisten", UserId = 1},
                new User(){FirstName = "Emilie", LastName = "Broen", EMail = "emilie.broen@gmail.com", UserName = "superwoman", UserId = 2}
             };
            _nextUserId = _localUsers.Last().UserId + 1; 
        }

        public async Task<User> AddUser(User newUser)
        {
            await Task.Delay(1); 
            var exising = _localUsers.FirstOrDefault(f => f.EMail.Equals(newUser.EMail));
            if (exising != null) return exising;
            else
            {
                newUser.UserId = _nextUserId;
                _nextUserId++;
                _localUsers.Add(newUser); 
                return newUser; 
            }
        }

        public async Task DeleteUser(User toDelet)
        {
            await Task.Delay(1);
            var exist = _localUsers.FirstOrDefault(f => f.UserId == toDelet.UserId);
            if (exist != null)
                _localUsers.Remove(exist); 
          
        }

        public List<User> GetAllUsers()
        {
            return _localUsers; 
        }

        public async Task<User> UpdateUser(User updated)
        {
            await Task.Delay(1);
            var exiting = _localUsers.Find(f => f.UserId.Equals(updated.UserId));
            if (exiting != null)
            {
                exiting = updated;
                return exiting;
            }
            return updated; 
        }
    }
}
