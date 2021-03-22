using BlazorHomepage.Shared.Data.Entities;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorHomepage.Server.DataHandlers
{
    public class MongoDBStorageContext : IMongoDbStorageContext
    {
        private readonly string DatabaseName ="ShoppingListsDB"; 

        private string connectionString; 
        public MongoDBStorageContext(IConfiguration appConfig)
        {
            connectionString = appConfig.GetConnectionString("MongoDB");
            DataBaseClient = new MongoClient(connectionString);
            DB = DataBaseClient.GetDatabase(DatabaseName); 
        }

        public MongoClient DataBaseClient { get; set; }

        public IMongoCollection<BsonDocument> ThisCollection { get; set; } 

        public IMongoDatabase DB { get; private set; }
        
        public string CollectionKey { get; set; }

        public string GetCollectionKey(Type toTypeGet)
        {
            if (toTypeGet == typeof(ShopItem))
                return "shopitems";
            if (toTypeGet == typeof(ItemCategory))
                return "itemcategories";
            if (toTypeGet == typeof(ShoppingList))
                return "shoppinglists";
            if (toTypeGet == typeof(Shop))
                return "shopcollection";
            return "misc";
        }

    }
}
