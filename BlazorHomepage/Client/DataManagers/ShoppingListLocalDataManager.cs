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
        private readonly IShoppingListStorageContext<ShoppingList> context;

        public ShoppingListLocalDataManager(IMapper mapper, IShoppingListStorageContext<ShoppingList> context)
        {
            this.mapper = mapper;
            this.context = context;
        }
        public void Add<T>(T entity) where T : class
        {
            try
            {
                if(entity is ShoppingListModel list)
                {
                    var shoppingList = mapper.Map<ShoppingList>(list);
                    context.Add(shoppingList);
                }
            }
            catch (Exception e)
            {
                Debug.Write(e);
            }
        }

        public void Delete<T>(T enitity) where T : class
        {
            if(enitity is ShoppingListModel list)
            {
                var shoppingList = mapper.Map<ShoppingList>(list);
                context.Delete(shoppingList);
            }
        }
        public T Update<T>(T entity) where T : class
        {
            if(entity  is ShoppingList list)
            {
                
                var shoppingList = mapper.Map<ShoppingList>(list);
                var res = context.Update(shoppingList);
                return mapper.Map<T>(res); 
            }
            return null; 
        }

        public async Task<ShoppingListModel[]> GetAllShoppingListsAsync()
        {
            await Task.Delay(1);
            var res = mapper.Map<ShoppingListModel[]>(context.StoredShoppingLists);
            return res; 
        }

        public  Task<ShopItemModel[]> GetAllShowItemsByShopIdAsync(string shopId)
        {
            throw new NotImplementedException(); 
            
        }

        public async Task<ShoppingListModel> GetOneShoppingListAsync(string listId)
        {
            await Task.Delay(1);
            var shoppingList = context.StoredShoppingLists.FirstOrDefault(f => f.ListId.Equals(listId));
            if (shoppingList == null) return null;
            else
                return mapper.Map<ShoppingListModel>(shoppingList);
        }

        public Task<ShelfModel[]> GetShelfByShowId(string shopId)
        {
            throw new NotImplementedException();
        }

        public async Task<ShoppingListModel> GetSortedHandlelisteAsync(string shopId)
        {
            await Task.Delay(1);
            var listen = context.StoredShoppingLists.First();
            var r = listen.ShoppingItems.OrderBy(f => f.Varen.ItemCategory.Name);
            listen.ShoppingItems = r.ToList(); 
            var result =  mapper.Map<ShoppingListModel>(listen);
            return result;
        }

        public async Task<bool> SaveChangesAsync()
        {
            await Task.Delay(1);
            return true; 
        }

        
    }
}
