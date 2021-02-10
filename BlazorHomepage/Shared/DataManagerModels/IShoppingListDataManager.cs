using BlazorHomepage.Shared.Data.Entities;
using BlazorHomepage.Shared.Model.HandlelisteModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorHomepage.Shared.DataManagerModels
{
   public  interface IShoppingListDataManager 
    {
		//Generic
		void Add<T>(T entity)  where T : class;

		void Delete<T>(T enitity)  where T : class;

		T Update<T>(T entity) where T : class; 

		Task<bool> SaveChangesAsync();

		//Handlelister
		Task<ShoppingListModel[]> GetAllShoppingListsAsync();
		Task<ShoppingListModel> GetOneShoppingListAsync(string listId);

		Task<ShoppingListModel> GetSortedHandlelisteAsync(string shopId);

		//ShopItems
		Task<ShopItemModel[]> GetAllShowItemsByShopIdAsync(string shopId);
		
		//shelfs
		Task<ShelfModel[]> GetShelfByShowId(string shopId);

	}
}
