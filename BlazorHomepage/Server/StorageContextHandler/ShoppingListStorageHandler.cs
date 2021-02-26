using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlazorHomepage.Shared.Data.Entities;
using BlazorHomepage.Shared.HandlelisteData;
using Google.Cloud.Firestore;
using Newtonsoft.Json;

namespace BlazorHomepage.Server.StorageContextHandler
{
    public class ShoppingListStorageHandler : GoogleNoSqlHandlerBase, IStorageContext<ShoppingList>
    {

        public ShoppingListStorageHandler() : base("Lister")
        {

        }

        public async Task<ICollection<ShoppingList>> GetStoredItems()
        {
            var storedLists = new List<ShoppingList>();


            var collecteionSnapShot = await Collection.GetSnapshotAsync();
            foreach (var docSnaps in collecteionSnapShot.Documents)
            {
                var oneShoppingList = docSnaps.ConvertTo<ShoppingList>();
                storedLists.Add(oneShoppingList);
            }
            return storedLists;
        }

        public async Task<ShoppingList> Add(ShoppingList shoppingList)
        {
            var newDocRef = Collection.Document();
            shoppingList.ListId = newDocRef.Id;
            shoppingList.TimeStamp = Timestamp.FromDateTime(DateTime.Now);
            await newDocRef.SetAsync(shoppingList, SetOptions.Overwrite);
            return shoppingList;
        }

        public async Task<bool> Delete(ShoppingList contact)
        {
            var docRef = Collection.Document(contact.ListId);
            await docRef.DeleteAsync();
            return true;
        }

        public async Task<ShoppingList> Update(ShoppingList updateListe)
        {
            var docRef = Collection.Document(updateListe.ListId);
            updateListe.TimeStamp = Timestamp.FromDateTime(DateTime.Now);
            await docRef.SetAsync(updateListe, SetOptions.Overwrite);
            return updateListe;
        }

        public async Task<ShoppingList> GetOneStoredItem(string id)
        {
            var docRef = await Collection.Document(id).GetSnapshotAsync();
            return docRef.ConvertTo<ShoppingList>();
        }
    }

}
