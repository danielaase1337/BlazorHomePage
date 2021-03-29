//using BlazorHomepage.Shared.Repository;
//using Microsoft.Extensions.Configuration;
//using MongoDB.Bson;
//using MongoDB.Driver;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Linq.Expressions;
//using System.Text;
//using System.Threading.Tasks;

//namespace BlazorHomepage.Server.DataHandlers
//{
//    public class MongoDBGenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : EntityBase
//    {
//        private readonly IMongoDbStorageContext<TEntity> dbContext;

//        public MongoDBGenericRepository(IMongoDbStorageContext<TEntity> dbInnContext)
//        {
//            dbContext = dbInnContext;
//            if (this.dbContext.ThisCollection == null)
//            {
//                dbContext.CollectionKey = dbContext.GetCollectionKey(typeof(TEntity));
//                dbContext.ThisCollection = dbContext.DB.GetCollection<TEntity>(dbContext.CollectionKey);
//            }
//        }

//        public async Task<bool> Delete(TEntity entityToDelete)
//        {
//            return await Delete(entityToDelete.Id); 
//        }

//        public async Task<bool> Delete(object id)
//        {
//            try
//            {
//                if(id is string idString)
//                {
//                   var res = await dbContext.ThisCollection.DeleteOneAsync(f => f.Id.Equals(new ObjectId(idString)));
//                    if (res.IsAcknowledged)
//                        return true;
//                    return false; 
//                }
//                return false; 
//            }
//            catch (Exception e)
//            {
//                Console.Write(e);
//                return false; 
//            }
//        }

//        public async Task<ICollection<TEntity>> Get(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "")
//        {
//            try
//            {
//                ICollection<TEntity> resultingEntities;

//                if (filter != null)
//                {
//                    var foundEntities = await dbContext.ThisCollection.FindAsync(filter);
//                    resultingEntities = await foundEntities.ToListAsync();
//                }
//                else
//                    resultingEntities = await dbContext.ThisCollection.AsQueryable().ToListAsync();

//                if(orderBy != null)
//                {
//                    //resultingEntities = resultingEntities.OrderBy(orderBy); 
//                }
//                return resultingEntities; 

//            }
//            catch (Exception e)
//            {
//                Console.Write(e);
//                return null; 
//            }
//        }

//        public async Task<TEntity> Get(object id)
//        {
//            try
//            {
//                if (id is string stringId)
//                {
//                    var res = await dbContext.ThisCollection.Find(f => f.Id.Equals(new ObjectId(stringId))).ToListAsync();
//                    if (!res.Any())
//                        return null;
//                    return res.First();
//                }
//            }
//            catch (Exception e)
//            {

//                Console.Write(e);
//            }
//            return null;
//        }

//        public async Task<TEntity> Insert(TEntity entity)
//        {
//            try
//            {
//                entity.Id = ObjectId.GenerateNewId().ToString();
//                await dbContext.ThisCollection.InsertOneAsync(entity);
//                return entity;
//            }
//            catch (Exception e)
//            {
//                Console.Write(e);
//                return null;
//            }
//        }

//        public async Task<TEntity> Update(TEntity entityToUpdate)
//        {
//            try
//            {
//                var res = await dbContext.ThisCollection.ReplaceOneAsync(f => f.Id.Equals(new ObjectId(entityToUpdate.Id)), entityToUpdate);
//                if (res.IsAcknowledged)
//                    return entityToUpdate;
//                return null; 
//            }
//            catch (Exception e)
//            {
//                Console.Write(e);
//                return null; 
//            }
//        }
//    }
//}
