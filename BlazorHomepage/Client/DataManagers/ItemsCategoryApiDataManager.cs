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
    public class ItemsCategoryApiDataManager<TEntity> : IGenericRepository<TEntity> where TEntity : EntityBase
    {
        private readonly HttpClient http;
        private readonly string BaseUrl;
        public ItemsCategoryApiDataManager(HttpClient http)
        {
            this.http = http;
            BaseUrl = "api/itemcategory/";
        }
        public async Task<bool> Delete(TEntity entityToDelete)
        {
           return  await Delete(entityToDelete.Id);
        }

        public async  Task<bool> Delete(object id)
        {
            if(id is string sId)
            {
                var url = BaseUrl + sId;
                var result = await http.DeleteAsync(url);
                var respons = await result.Content.ReadAsStringAsync();
                var resobject = JsonConvert.DeserializeObject<bool>(respons);
                return resobject;
            }
            return false; 
        }

        public async Task<ICollection<TEntity>> Get(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "")
        {
            //må legge inn søk osv.. 
            var result = await http.GetAsync(BaseUrl);
            var respons = await result.Content.ReadAsStringAsync();
            var resobject = JsonConvert.DeserializeObject<ICollection<TEntity>>(respons);
            if (resobject != null)
                return resobject;
            return null; 
        }

        public async Task<TEntity> Get(object id)
        {
            if (id is string sId)
            {
                var url = BaseUrl + sId.ToString();
                var result = await http.GetAsync(url);
                //result.EnsureSuccessStatusCode();
                var respons = await result.Content.ReadAsStringAsync();
                var resobject = JsonConvert.DeserializeObject<TEntity>(respons);
                if (resobject != null)
                    return resobject;
            }
            return null;
        }

        public async  Task<TEntity> Insert(TEntity entity)
        {
            var jsonHttpContent = JsonContent.Create(entity);
            var respons = await http.PostAsync(BaseUrl, jsonHttpContent);
            var result = await respons.Content.ReadAsStringAsync();
            var resobject = JsonConvert.DeserializeObject<TEntity>(result);
            if (resobject != null) return resobject;
            return null; 
        }

        public async  Task<TEntity> Update(TEntity entityToUpdate)
        {
            var jsonHttpContent = JsonContent.Create(entityToUpdate);
            var respons = await http.PutAsync(BaseUrl, jsonHttpContent);
            var result = await respons.Content.ReadAsStringAsync();
            var resobject = JsonConvert.DeserializeObject<TEntity>(result);
            if (resobject != null) return resobject;
            return null;
        }

      
    }
}
