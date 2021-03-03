using Google.Cloud.Firestore;
using System;

namespace BlazorHomepage.Shared.Repository
{
    public interface IGoogleFireBaseDbContext
    {
        string CollectionKey { get; set; }
        CollectionReference Collection { get; set; }
        FirestoreDb DB { get;  }
        //string GetCollectionKey(object toTypeGet);
        string GetCollectionKey(Type toTypeGet);
    }

}
