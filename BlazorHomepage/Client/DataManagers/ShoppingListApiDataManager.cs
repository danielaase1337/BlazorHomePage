using BlazorHomepage.Shared.Repository;
using System.Net.Http;

namespace BlazorHomepage.Client.DataManagers
{
    public class ShoppingListApiDataManager<TEntity> : ApiDataManagerBase<TEntity> where TEntity: EntityBase
    {
        public ShoppingListApiDataManager(HttpClient http): base("api/shoppinglist/", http)
        {

        }
    }
}
