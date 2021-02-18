using BlazorHomepage.Shared.DataManagerModels;
using BlazorHomepage.Shared.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorHomepage.Client.DataManagers
{
    public class LocalUserDataManager : IUserDataManager<User>
    {
        private List<User> _localUsers;
        private int _nextUserId;
        public LocalUserDataManager()
        {
            OnInitiliazing();

        }


        public T Add<T>(T entity) where T : class
        {
            if(entity is User newUser)
            {
                var exising = _localUsers.FirstOrDefault(f => f.EMail.Equals(newUser.EMail));
                if (exising != null) return exising as T;
                else
                {
                    newUser.UserId = _nextUserId;
                    _nextUserId++;
                    _localUsers.Add(newUser);
                    return newUser as T;
                }
            }
            return null; 
        }

        public bool Delete<T>(T entity) where T : class
        {
            if (entity is User user)
            {
                var exist = _localUsers.FirstOrDefault(f => f.UserId == user.UserId);
                if (exist != null)
                {
                    _localUsers.Remove(exist);
                    return true;
                }
            }
            return false;
        }

        public async Task<User[]> GetAllUsersAsync()
        {
            await Task.Delay(1);
            return _localUsers.ToArray();
        }

        public async Task<User> GetUsersAsync(string id)
        {
            await Task.Delay(1);
            var ok = int.TryParse(id, out int thisId);
            if (!ok) return null;
            var existing = _localUsers.FirstOrDefault(f => f.UserId == thisId);
            return existing;
        }

        public void OnInitiliazing()
        {
            _localUsers = new List<User>()
            {
                new User(){FirstName = "Daniel", LastName = "Aase", EMail = "aase.daniel@gmail.com", UserName = "supergnisten", UserId = 1},
                new User(){FirstName = "Emilie", LastName = "Broen", EMail = "emilie.broen@gmail.com", UserName = "superwoman", UserId = 2}
             };
            _nextUserId = _localUsers.Last().UserId + 1;

        }

        public async Task<bool> SaveChangesAsync()
        {
            await Task.Delay(1);
            return true;
        }

        public T Update<T>(T entity) where T : class
        {
            if (entity is User updated)
            {
                var exiting = _localUsers.Find(f => f.UserId.Equals(updated.UserId));
                if (exiting != null)
                {
                    exiting = updated;
                    return exiting as T;
                }
            }
            return entity as T;
        }

    }
}
