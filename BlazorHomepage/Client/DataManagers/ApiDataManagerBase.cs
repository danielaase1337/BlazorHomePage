using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using BlazorHomepage.Shared.Repository;
using Newtonsoft.Json;

namespace BlazorHomepage.Client.DataManagers
{
    /// <summary>
    /// A baseclass for preforming Api calls to different controllers, 
    /// Eacht class that inheriths this has its own TEnityt Type
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public abstract class ApiDataManagerBase<TEntity> : IGenericRepository<TEntity> where TEntity : EntityBase
    {
        internal readonly string BaseUrl;
        private readonly HttpClient http;

        public ApiDataManagerBase(string baseurl, HttpClient http)
        {
            BaseUrl = baseurl;
            this.http = http;
        }
        public virtual async Task<bool> Delete(TEntity entityToDelete)
        {
            return await Delete(entityToDelete.Id);
        }

        public virtual async Task<bool> Delete(object id)
        {
            if (id is string sId)
            {
                var url = BaseUrl + sId; 
                var respons = await http.DeleteAsync(url);
                if (respons.StatusCode == System.Net.HttpStatusCode.NoContent)
                    return true;
                else return false; 
            }
            return false;

        }

        public virtual async Task<ICollection<TEntity>> Get(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "")
        {
            var respons = await http.GetAsync(BaseUrl);
            var result = await respons.Content.ReadAsStringAsync();
            var resobject = JsonConvert.DeserializeObject<ICollection<TEntity>>(result);
            return resobject;
        }

        public virtual async Task<TEntity> Get(object id)
        {
            if (id is string sId)
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

        public virtual async Task<TEntity> Insert(TEntity entity)
        {
            var jsonContent = JsonContent.Create(entity);
            var respons = await http.PostAsync(BaseUrl, jsonContent);
            
            if (respons.StatusCode == System.Net.HttpStatusCode.NoContent) //Existing.. tregnger ikke legge til.. 
                return entity;

            var result = await respons.Content.ReadAsStringAsync();
            var resobject = JsonConvert.DeserializeObject<TEntity>(result);
            return resobject;
        }

        public virtual async Task<TEntity> Update(TEntity entityToUpdate)
        {
            var jsoncontent = JsonContent.Create(entityToUpdate);
            var respons = await http.PutAsync(BaseUrl, jsoncontent);
            var result = await respons.Content.ReadAsStringAsync();
            var resobject = JsonConvert.DeserializeObject<TEntity>(result);
            return resobject;
        }
    }
}
