using BlazorHomepage.Shared.Model.GoogleModels;
using Google.Cloud.Firestore;

namespace BlazorHomepage.Shared.Repository
{
    public interface IGoogleFireBaseDbContext
    {
        IGoogleCollectionType CollectionType { get;  }
        CollectionReference Collection { get; set; }
        DocumentReference KeyDocument { get; set; }
        FirestoreDb DB { get; }
    }

}
