using BlazorHomepage.Shared.Data.Entities;
using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BlazorHomepage.Shared.Repository
{
    public class GoogleFirebaseGenenricRepository<TEntity> : IGenericRepository<TEntity>
        where TEntity : EntityBase
    {
        private readonly IGoogleFireBaseDbContext dbContext;

        public GoogleFirebaseGenenricRepository(IGoogleFireBaseDbContext dbContext)
        {
            this.dbContext = dbContext;
            if(this.dbContext.Collection == null)
            {
                dbContext.CollectionKey = dbContext.GetCollectionKey(typeof(TEntity));
                dbContext.Collection = dbContext.DB.Collection(dbContext.CollectionKey);
            }
        }

        public async Task<bool> Delete(TEntity entityToDelete)
        {
            try
            {
                var id = entityToDelete.Id;
                await dbContext.Collection.Document(id).DeleteAsync();
                return true;
            }
            catch (Exception e)
            {
                Debug.Write(e);
                return false;
            }
        }

        public async Task<bool> Delete(object id)
        {


            if (id == null)
                return false;
            try
            {
                if (id is string sId)
                {
                    if (string.IsNullOrEmpty(sId))
                        return false;
                    await dbContext.Collection.Document(sId).DeleteAsync();
                    return true;
                }
                return false;

            }
            catch (Exception e)
            {
                Debug.Write(e);
                return false;
            }
        }

        public async Task<ICollection<TEntity>> Get(Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>,
                IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "")
        {

            //Har implementert en litt dårlig løsning her. Det finnes enmulighet
            // for å utføre spørringen før man henter data fra server. 
            //Dette må nok gjøres, men ikke med en gang. 
            // se her for overføring av data fra linq
            //https://www.codementor.io/@juliandambrosio/how-to-use-expression-trees-to-build-dynamic-queries-c-xyk1l2l82
            //Må vurdere og det er mest hensiktsmessing å ha denne måten å filtrere på .. 
            try
            {

                var snapshot = await dbContext.Collection.GetSnapshotAsync();
                var shopItems = new Collection<TEntity>();
                var res = snapshot.Documents.Select(f => f.ConvertTo<TEntity>());

                IQueryable<TEntity> query = res.AsQueryable();
                if (filter != null)
                {
                    query = query.Where(filter);
                    //en helper som kanskje kan brukes ? 
                }
                if (orderBy != null)
                {
                    return orderBy(query).ToList();
                }
                else
                  return   query.ToList();
            }
            catch (Exception e)
            {
                Console.Write(e);
            }
            return null;
        }

        public async Task<TEntity> Get(object id)
        {
            //if (id.ToString().Equals("22"))
            //{
            //    return await Task.Run(() =>
            //    {
            //        return new ShoppingList()
            //        {
            //            Name = "handleliste 2",
            //            Id = id.ToString(),
            //            IsDone = false,
            //            ListId = id.ToString(),
            //            ShoppingItems = new List<ShoppingListItem>(),
            //            TimeStamp = Timestamp.GetCurrentTimestamp()
            //        } as TEntity ;
            //    });
            //}

            //return await Task.Run(() =>
            //{
            //    return
            //    new ShopItem
            //    {
            //        Id = id.ToString(),
            //        Name = "Melk",
            //        Unit = "Liter",
            //        TimeStamp = Timestamp.GetCurrentTimestamp(),
            //        ItemCategory = new ItemCategory() { Name = "Meieri" }
            //    } as TEntity;
            //});

            try
            {
                if (id is string stringId)
                {
                    var docref = dbContext.Collection.Document(stringId);
                    var res = await docref.GetSnapshotAsync();
                    return res.ConvertTo<TEntity>();
                }
            }
            catch (Exception e)
            {
                Console.Write(e.Message);
            }

            return null;
        }


        public async Task<TEntity> Insert(TEntity entity)
        {
            try
            {
                var addedDocRes = dbContext.Collection.Document();
                entity.Id = addedDocRes.Id;
                //entity.TimeStamp = Timestamp.GetCurrentTimestamp();
                await addedDocRes.SetAsync(entity);
                return entity;
            }
            catch (Exception e)
            {
                Debug.Write(e.Message);
            }
            return null;
        }

        public async Task<TEntity> Update(TEntity entityToUpdate)
        {
            var updateRef = dbContext.Collection.Document(entityToUpdate.Id);
            //entityToUpdate.TimeStamp = Timestamp.GetCurrentTimestamp(); 
            await updateRef.SetAsync(entityToUpdate);
            return entityToUpdate;
        }
    }
}
