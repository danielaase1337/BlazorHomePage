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
    public class Shop : EntityBase
    {
        [FirestoreProperty]
        public ICollection<Shelf> ShelfsInShop { get; set; }

    }
}
