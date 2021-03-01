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
    public class ShopItem : EntityBase
    {
        [FirestoreProperty]
        public string Name { get; set; }
        [FirestoreProperty]
        public string Unit { get; set; } //Stk, vekt osv.. 
        [FirestoreProperty]
        public ItemCategory ItemCategory { get; set; }

    }
}
