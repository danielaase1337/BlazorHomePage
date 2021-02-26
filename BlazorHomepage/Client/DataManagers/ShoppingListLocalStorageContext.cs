using BlazorHomepage.Shared.Data.Entities;
using BlazorHomepage.Shared.HandlelisteData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorHomepage.Client.DataManagers
{
    public class ShoppingListLocalStorageContext : IStorageContext
    {


        public ShoppingListLocalStorageContext()
        {
            OnInitiliazing();
        }

        private ICollection<ShoppingList> StoredShoppingLists;
        private ICollection<ItemCategory> AvailableItemCategories;
        private ICollection<ShopItem> AvailableShopItems; 
        private int _nextId;
        private int _nextCatId;
        private int _nextShopItemId; 

        public ICollection<T> GetStoredItems<T>(T typeToGet) where T : class
        {
            if(typeToGet is ShoppingList)
                return StoredShoppingLists as ICollection<T>; 
            if (typeToGet is ItemCategory)
                return AvailableItemCategories as ICollection<T>;
            if (typeToGet is ShopItem)
                return AvailableShopItems as ICollection<T>;
            return null; 
        }
       
        public T Add<T>(T entity) where T : class
        {
            if (entity is ShoppingList list)
            {
                if (!StoredShoppingLists.Contains(list))
                {
                    list.ListId = _nextId.ToString();
                    _nextId++;
                    StoredShoppingLists.Add(list);
                }
                return list as T;
            }
            if(entity is ItemCategory cat)
            {
                if(!AvailableItemCategories.Contains(cat))
                {
                    cat.Id = _nextCatId.ToString();
                    _nextCatId++; 
                    AvailableItemCategories.Add(cat);
                    return cat as T; 
                }
                else return cat as T; 

            }
            if(entity is ShopItem item)
            {
                if (!AvailableShopItems.Contains(item))
                {
                    item.Id = _nextShopItemId.ToString();
                    _nextShopItemId++;
                    AvailableShopItems.Add(item);
                    return item as T;
                }
                else return item as T; 
            }
            return null;
        }

        public bool Delete<T>(T entity) where T : class
        {
            if (entity is ShoppingList list)
            {
                var exist = StoredShoppingLists.FirstOrDefault(f => f.ListId == list.ListId);
                if (exist == null) return false;
                else
                {
                    StoredShoppingLists.Remove(exist);
                    return true;
                }
            }
            if(entity is ItemCategory cat)
            {
                var exist = AvailableItemCategories.FirstOrDefault(f => f.Id == cat.Id);
                if (exist == null) return false; 
                else
                {
                    AvailableItemCategories.Remove(exist);
                    return true; 
                }
            }
            if(entity is ShopItem item)
            {
                var exist = AvailableShopItems.FirstOrDefault(f => f.Id == item.Id);
                if (exist == null) return false;
                else
                {
                    AvailableShopItems.Remove(item);
                    return false; 

                }

            }
            return false;
        }
        public T Update<T>(T entity) where T : class
        {
            if (entity is ShoppingList list)
            {
                var exisitng = StoredShoppingLists.FirstOrDefault(a => a.ListId == list.ListId);
                if (exisitng == null) return null;
                exisitng = list;
                return list as T;
            }
            return null;
        }

        public void OnInitiliazing()
        {
            if (StoredShoppingLists == null)
            {
                AvailableItemCategories = ItemCategory.GetDefaults();
                AvailableShopItems = ShopItem.GetDefault();

                var shopitemList = AvailableShopItems.Select(f => new ShoppingListItem() {IsDone = false, Mengde = 1, Varen = f });
                StoredShoppingLists = new List<ShoppingList>()
            {
                new ShoppingList(){Name = "Handleliste Uke 1", ListId = "1", IsDone = false,
                    ShoppingItems = shopitemList.ToList(),
                }
            };
                _nextId = int.Parse(StoredShoppingLists.Last().ListId) + 1;
                _nextCatId =int.Parse(AvailableItemCategories.Last().Id) + 1;
                _nextShopItemId = int.Parse(AvailableShopItems.Last().Id) + 1; 

            }

        }

       


    }
}
