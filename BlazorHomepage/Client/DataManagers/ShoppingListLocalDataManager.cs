using AutoMapper;
using BlazorHomepage.Shared.Data.Entities;
using BlazorHomepage.Shared.DataManagerModels;
using BlazorHomepage.Shared.HandlelisteData;
using BlazorHomepage.Shared.Model.HandlelisteModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorHomepage.Client.DataManagers
{
    public class ShoppingListLocalDataManager : IShoppingListDataManager
    {
        private readonly IMapper mapper;
        private readonly IStorageContext _storeContext;
        private readonly ShoppingList shopListTypeSelector;
        private readonly ItemCategory itemCategoryTypeSelector;
        private readonly ShopItem shopItemTypeSelector;
        public IMapper Mapper => mapper;

        public IStorageContext StoreContext => _storeContext;

        public ShoppingListLocalDataManager(IMapper mapper, IStorageContext context)
        {
            shopListTypeSelector = new ShoppingList();
            itemCategoryTypeSelector = new ItemCategory();
            shopItemTypeSelector = new ShopItem(); 
            
            this.mapper = mapper;
            this._storeContext = context;
        }
        public async Task<T> Add<T>(T entity) where T : class
        {
            await Task.Delay(1);
            try
            {
                if (entity is ShoppingListModel list)
                {
                    var shoppingList = Mapper.Map<ShoppingList>(list);
                    var res = StoreContext.Add(shoppingList);
                    list.Id = res.Id;
                    return list as T;
                }
                if(entity is ShopItemModel item)
                {
                    var shopItem = Mapper.Map<ShopItem>(item);
                    var res = StoreContext.Add(shopItem);
                    return item as T; 
                }
                if(entity is ItemCategoryModel itemCat)
                {
                    var category = Mapper.Map<ItemCategory>(itemCat);
                    var res = StoreContext.Add(category);
                    return itemCat as T; 
                }
            }
            catch (Exception e)
            {
                Debug.Write(e);
                return null;
            }
            return null;
        }

        public async Task<bool> Delete<T>(T enitity) where T : class
        {
            await Task.Delay(1);

            if (enitity is ShoppingListModel list)
            {
                try
                {
                    var shoppingList = Mapper.Map<ShoppingList>(list);
                   var res = StoreContext.Delete(shoppingList);
                   return res; 
                }
                catch (Exception e)
                {
                    Debug.Write(e);
                    return false;
                }
            }
            return false;
        }
        public async Task<T> Update<T>(T entity) where T : class
        {
            await Task.Delay(1);
            if (entity is ShoppingListModel list)
            {

                var shoppingList = Mapper.Map<ShoppingList>(list);
                var res = StoreContext.Update(shoppingList);
                return Mapper.Map<T>(res);
            }
            return null;
        }

        public async Task<List<ShoppingListModel>> GetAllShoppingListsAsync()
        {
            await Task.Delay(1);
            var storedItems = StoreContext.GetStoredItems(shopListTypeSelector);
            var res = Mapper.Map<ShoppingListModel[]>(storedItems);
            return res.ToList();
        }


        public async Task<ShoppingListModel> GetOneShoppingListAsync(string listId)
        {
            await Task.Delay(1);
            var res = StoreContext.GetStoredItems(shopListTypeSelector);
            var shoppingList = res.FirstOrDefault(f => f.ListId.Equals(listId));
            if (shoppingList == null) return null;
            else
                return Mapper.Map<ShoppingListModel>(shoppingList);
        }

        public Task<List<ShelfModel>> GetShelfByShowId(string shopId)
        {
            throw new NotImplementedException();
        }

        public async Task<ShoppingListModel> GetSortedHandlelisteAsync(string shopId)
        {
            await Task.Delay(1);
            var listen = StoreContext.GetStoredItems(shopListTypeSelector).First();
            var r = listen.ShoppingItems.OrderBy(f => f.Varen.ItemCategory.Name);
            listen.ShoppingItems = r.ToList();
            var result = Mapper.Map<ShoppingListModel>(listen);
            return result;
        }

        public async Task<bool> SaveChangesAsync()
        {
            await Task.Delay(1);
            return true;
        }

       
        public async Task<List<ShopItemModel>> GetAllShopItemsAsync()
        {
            await Task.Delay(1);
            var items = StoreContext.GetStoredItems(shopItemTypeSelector);
            return mapper.Map<ShopItemModel[]>(items).ToList();
        }

        public async Task<List<ItemCategoryModel>> GetAllItemCategories()
        {
            await Task.Delay(1);
            var items = StoreContext.GetStoredItems(itemCategoryTypeSelector);
            return mapper.Map<ItemCategoryModel[]>(items).ToList(); 
        }
    }
}
