using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorHomepage.Shared.Repository
{
    [FirestoreData]
    public class EntityBase
    {
        [FirestoreProperty]
        public string Id { get; set; }

        [FirestoreProperty]
        public Timestamp TimeStamp { get; set; }
    }
}
