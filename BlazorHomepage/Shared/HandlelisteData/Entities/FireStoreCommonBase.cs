using BlazorHomepage.Shared.Repository;
using Google.Cloud.Firestore;
using System;

namespace BlazorHomepage.Shared.Data.Entities
{
    [FirestoreData]
    public class FireStoreCommonBase : EntityBase
    {
        [FirestoreProperty]
        public Timestamp TimeStamp { get; set; }
    }
}