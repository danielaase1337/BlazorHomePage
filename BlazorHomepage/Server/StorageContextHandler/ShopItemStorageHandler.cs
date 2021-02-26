using BlazorHomepage.Shared.Data.Entities;
using BlazorHomepage.Shared.HandlelisteData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorHomepage.Server.StorageContextHandler
{
    public class ShopItemStorageHandler : GoogleNoSqlHandlerBase, IStorageContext<ShopItem>
    {

        public ShopItemStorageHandler() : base("ShopItems") { }


        public async Task<ShopItem> Add(ShopItem shopItem)
        {
            var addedDocRes = Collection.Document();
            shopItem.Id = addedDocRes.Id;
            shopItem.TimeStamp = Google.Cloud.Firestore.Timestamp.FromDateTime(DateTime.Now);
            await addedDocRes.SetAsync(shopItem);
            return shopItem;
        }

        public async Task<bool> Delete(ShopItem item)
        {
            var id = item.Id;
            await Collection.Document(id).DeleteAsync();
            return true;
        }

        public async Task<ShopItem> GetOneStoredItem(string id)
        {
            var docref = Collection.Document(id);
            var res = await docref.GetSnapshotAsync();
            return res.ConvertTo<ShopItem>();
        }

        public async Task<ICollection<ShopItem>> GetStoredItems()
        {

            var snapshot = await Collection.GetSnapshotAsync();
            var shopItems = new List<ShopItem>();
            foreach (var doc in snapshot.Documents)
            {
                var oneShopItem = doc.ConvertTo<ShopItem>();
                shopItems.Add(oneShopItem);
            }
            return shopItems;
        }

        public async Task<ShopItem> Update(ShopItem updatedShopItem)
        {
            var updateRef = Collection.Document(updatedShopItem.Id);
            updatedShopItem.TimeStamp = Google.Cloud.Firestore.Timestamp.FromDateTime(DateTime.Now);
            await updateRef.SetAsync(updatedShopItem);
            return updatedShopItem;
        }



    }
}
