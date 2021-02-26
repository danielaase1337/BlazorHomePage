using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorHomepage.Shared.Data.Entities
{
    [FirestoreData]
    public class Shop
    {
        [FirestoreProperty]
        public string Name { get; set; }
        [FirestoreProperty]
        public string Identificator { get; set; }
        [FirestoreProperty]
        public string Id { get; set; }
        [FirestoreProperty]
        public ICollection<Shelf> Shelfs { get; set; }

    }
}
