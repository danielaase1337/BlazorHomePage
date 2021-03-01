using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorHomepage.Shared.Model.GoogleModels
{
    public class UserCollectionModel : IGoogleCollectionType
    {
        public string CollectionName => "Users";
    }
}
