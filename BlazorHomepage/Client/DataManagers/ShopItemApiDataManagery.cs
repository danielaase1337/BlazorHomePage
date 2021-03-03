using BlazorHomepage.Shared.Model.HandlelisteModels;
using System.Net.Http;


namespace BlazorHomepage.Client.DataManagers
{
    public class ShopItemApiDataManagery<TEntity> : ApiDataManagerBase<TEntity> where TEntity : ShopItemModel
    {
        public ShopItemApiDataManagery(HttpClient http) :base("api/shopitems/", http)
        {

        }
    }
}
