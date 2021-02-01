using BlazorHomepage.Shared.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorHomepage.Shared.DataManagerModels
{
    public interface IUserDataManager
    {
        Task<User> AddUser(User newUser);

        Task DeleteUser(User toDelet);

        Task<User> UpdateUser(User updated); 

        List<User> GetAllUsers(); 

    }
}
