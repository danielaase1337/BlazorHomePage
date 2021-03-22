using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorHomepage.Server.DataHandlers
{
    public interface IMongoDbStorageContext<TEntity> where TEntity :class
    {
        MongoClient DataBaseClient { get; set; }

        IMongoCollection<TEntity> ThisCollection { get; set; }
        IMongoDatabase DB { get;  }

        string CollectionKey { get; set; }

        string GetCollectionKey(Type toTypeGet); 
    }
}
