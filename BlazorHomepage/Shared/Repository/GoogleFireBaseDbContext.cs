using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlazorHomepage.Shared.Model.GoogleModels;
using Google.Cloud.Firestore;

namespace BlazorHomepage.Shared.Repository
{
    public abstract class GoogleFireBaseDbContext  : IGoogleFireBaseDbContext
    {
        readonly string _projectId = "supergnisten-shoppinglist";
        internal readonly string _collectionKey;

        public GoogleFireBaseDbContext(IGoogleCollectionType collectiontype)
        {
            CollectionType = collectiontype; 
            _collectionKey = CollectionType.CollectionName;
            DB = FirestoreDb.Create(_projectId);
            Collection = DB.Collection(_collectionKey);
            KeyDocument = DB.Collection("keycollection").Document("KeyStorage");
        }
        public  CollectionReference Collection { get; set; }
        public  DocumentReference KeyDocument { get; set; }
        public FirestoreDb DB { get;  }
        public  IGoogleCollectionType CollectionType { get; }

    }    
}
