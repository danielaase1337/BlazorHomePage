using BlazorHomepage.Shared.Repository;
using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorHomepage.Shared.Data.Entities
{
    [FirestoreData]
    public class ItemCategory:EntityBase

    {
        public ItemCategory()
        {

        }
        public ItemCategory(string name, string id)
        {
            Name = name;
            Id = id; 
        }
        [FirestoreProperty]

        public string Name { get; set; }
        
    }

}
