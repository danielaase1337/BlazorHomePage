using Google.Cloud.Firestore;
using System;

namespace BlazorHomepage.Shared.Data.Entities
{
    [FirestoreData]
    public class FireStoreCommonBase
    {
        [FirestoreProperty]
        public Timestamp TimeStamp { get; set; }
    }
}