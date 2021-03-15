using BlazorHomepage.Shared.Repository;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace BlazorHomepage.Client.DataManagers
{
    public class ItemsCategoryApiDataManager<TEntity> : ApiDataManagerBase<TEntity> where TEntity : EntityBase
    {
        //private readonly HttpClient http;
        //private readonly string BaseUrl;
        public ItemsCategoryApiDataManager(HttpClient http) : base("api/itemcategory/", http)
        {
      
        }
    }
}
