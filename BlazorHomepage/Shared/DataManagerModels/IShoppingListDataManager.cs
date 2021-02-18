using BlazorHomepage.Shared.Data.Entities;
using BlazorHomepage.Shared.Model.HandlelisteModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorHomepage.Shared.DataManagerModels
{
    public interface IShoppingListDataManager
    {
        //Generic
        Task<T> Add<T>(T entity) where T : class;

        Task<bool> Delete<T>(T enitity) where T : class;

        Task<T> Update<T>(T entity) where T : class;

        Task<bool> SaveChangesAsync();

        //Handlelister
        Task<List<ShoppingListModel>> GetAllShoppingListsAsync();
        Task<ShoppingListModel> GetOneShoppingListAsync(int listId);
        Task<ShoppingListModel> GetSortedHandlelisteAsync(int shopId);

        //ShopItems
        Task<List<ShopItemModel>> GetAllShopItemsAsync();
        Task<List<ItemCategoryModel>> GetAllItemCategories();


        //shelfs
        Task<List<ShelfModel>> GetShelfByShowId(string shopId);

    }
}
