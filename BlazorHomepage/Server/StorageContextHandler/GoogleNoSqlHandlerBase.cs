using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Cloud.Firestore;


namespace BlazorHomepage.Server.StorageContextHandler
{
    public abstract class GoogleNoSqlHandlerBase
    {
        readonly string _projectId = "supergnisten-shoppinglist";
        internal readonly string _collectionKey;

        public GoogleNoSqlHandlerBase(string collectionName)
        {
            _collectionKey = collectionName;
            DB = FirestoreDb.Create(_projectId);
            Collection = DB.Collection(collectionName);
            KeyDocument = DB.Collection("keycollection").Document("KeyStorage");
        }
        internal CollectionReference Collection { get; set; }
        internal DocumentReference KeyDocument { get; set; }

        internal readonly FirestoreDb DB;

    }
}
