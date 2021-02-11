using BlazorHomepage.Shared.Data.Entities;
using BlazorHomepage.Shared.HandlelisteData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorHomepage.Client.DataManagers
{
    public class ShoppingListLocalStorageContext: IShoppingListStorageContext<ShoppingList>
    {


        public ShoppingListLocalStorageContext()
        {
            OnInitiliazing(); 
        }

        public ICollection<ShoppingList> StoredShoppingLists { get; set; }
        public  ICollection<ItemCategory> AvailableItemCategories { get; set; }
        public ICollection<ShopItem> AvailableShopItems { get; set; }
        private int _nextId; 
        public void Add(ShoppingList list)
        {
            if(!StoredShoppingLists.Contains(list))
                StoredShoppingLists.Add(list); 
        }

        public bool Delete(ShoppingList contact)
        {
            var exist = StoredShoppingLists.FirstOrDefault(f => f.ListId == contact.ListId);
            if (exist == null) return false;
            else
            {
                StoredShoppingLists.Remove(exist);
                return true; 
            }
        }

        public void OnInitiliazing()
        {
            if(StoredShoppingLists == null)
            {
                AvailableItemCategories = ItemCategory.GetDefaults();
                AvailableShopItems = ShopItem.GetDefault();

                var shopitemList = AvailableShopItems.Select(f => new ShoppingListItem() { Id = f.Id, IsDone = f.Done, Mengde = 1, Varen = f });
                StoredShoppingLists = new List<ShoppingList>()
            {
                new ShoppingList(){Name = "Handleliste Uke 1", ListId = 1, IsDone = false,
                    ShoppingItems = shopitemList.ToList(),
                }
            };
                _nextId = StoredShoppingLists.Last().ListId + 1;

            }

        }

        public ShoppingList Update(ShoppingList updatedContact)
        {
            var exisitng = StoredShoppingLists.FirstOrDefault(a => a.ListId == updatedContact.ListId);
            if (exisitng == null) return null;
            exisitng = updatedContact;
            return updatedContact; 
        }
    }
}
