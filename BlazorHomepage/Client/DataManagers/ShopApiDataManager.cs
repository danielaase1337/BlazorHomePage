using BlazorHomepage.Shared.Repository;
using System.Net.Http;

namespace BlazorHomepage.Client.DataManagers
{
    public class ShopApiDataManager<TEntity> : ApiDataManagerBase<TEntity> where TEntity: EntityBase
    {
        public ShopApiDataManager(HttpClient http): base("api/shops/", http)
        {

        }
    }
}
