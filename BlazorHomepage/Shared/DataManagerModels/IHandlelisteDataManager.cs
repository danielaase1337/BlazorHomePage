using BlazorHomepage.Shared.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorHomepage.Shared.DataManagerModels
{
    interface IHandlelisteDataManager
    {
		//Generic
		void Add<T>(T entity)  where T : class;

		void Delete<T>(T enitity)  where T : class;

		Task<bool> SaveChangesAsync();

		//Handlelister
		Task<ShoppingList[]> GetAllShoppingListsAsync();
		Task<ShoppingList> GetOneShoppingListAsync(string listId);

		Task<ShoppingList> GetSortedHandlelisteAsync(string shopId);

		//ShopItems
		Task<ShopItem[]> GetAllShowItemsByShopIdAsync(string shopId);
		
		//shelfs
		Task<Shelf[]> GetShelfByShowId(string shopId);

	}
}
