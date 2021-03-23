using BlazorHomepage.Shared.Model.HandlelisteModels;
using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorHomepage.Shared.Repository
{
    [FirestoreData]
    public class EntityBase : IEntityBase
    {
        [FirestoreProperty]
        public string Id { get; set; }

        [FirestoreProperty]
        public string Name { get; set; }

        public string CssComleteEditClassName
        {
            get
            {
                if (EditClicked)
                    return "edit";
                else return "";
            }
        }

        public bool EditClicked { get; set; }
    }
}
