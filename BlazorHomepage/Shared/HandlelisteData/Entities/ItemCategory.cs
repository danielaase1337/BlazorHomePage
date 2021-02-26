using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorHomepage.Shared.Data.Entities
{
    [FirestoreData]
    public class ItemCategory
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
        [FirestoreProperty]
        public string  Id { get; set; }
        
        public static List<ItemCategory> GetDefaults()
        {
            var res = new List<ItemCategory>()
            {
                new ItemCategory("Meieri", "1"),
                new ItemCategory("Frukt", "2"),
                new ItemCategory("Brød", "3"),
                new ItemCategory("Kjøl", "4"),
                new ItemCategory("Tørrvare", "5"),
                new ItemCategory("Frys", "6"),
                new ItemCategory("Drikke", "7"),
                new ItemCategory("Ferskvare", "8")
            };

            return res; 
        }
    }

}
