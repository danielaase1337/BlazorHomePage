using BlazorHomepage.Shared.Model;
using BlazorHomepage.Shared.Model.HandlelisteModels;
using BlazorHomepage.Shared.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorHomepage.Shared.UserData
{
    public class UserSettingsModel : EntityBase
    {
        public User ThisUser { get; set; }
        public ICollection<ShopModel> MyShops { get; set; } = new List<ShopModel>(); 
        
    }
}
