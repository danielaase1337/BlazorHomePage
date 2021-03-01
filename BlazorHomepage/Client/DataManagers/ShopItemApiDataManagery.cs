using BlazorHomepage.Shared.Model.HandlelisteModels;
using BlazorHomepage.Shared.Repository;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BlazorHomepage.Client.DataManagers
{
    public class ShopItemApiDataManagery<TEntity> : IGenericRepository<TEntity> where TEntity: ShopItemModel
    {
        private readonly HttpClient http;
        private readonly string BaseUrl; 
        public ShopItemApiDataManagery(HttpClient http)
        {
            this.http = http;
            BaseUrl = "api/shopitems/";
        }

        public Task<bool> Delete(TEntity entityToDelete)
        {
            
            throw new NotImplementedException();
        }

        public Task<bool> Delete(object id)
        {
            throw new NotImplementedException();
        }

        public async  Task<ICollection<TEntity>> Get(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "")
        {
            return await Task.Run(() => {
                return new List<TEntity>(); 
            });
        }

        public async Task<TEntity> Get(object id)
        {
            if(id is string sId)
            {
                var url = BaseUrl + sId;
                var result = await http.GetAsync(url);
                //result.EnsureSuccessStatusCode();
                var respons = await result.Content.ReadAsStringAsync();
                var resobject = JsonConvert.DeserializeObject<TEntity>(respons);
                if (resobject != null)
                    return resobject;
            }
            
            return null; 

        }

        public Task<TEntity> Insert(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> Update(TEntity entityToUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
