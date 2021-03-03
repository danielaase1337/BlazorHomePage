using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlazorHomepage.Shared.Data.Entities;
using Google.Cloud.Firestore;

namespace BlazorHomepage.Shared.Repository
{
    public  class GoogleFireBaseDbContext  : IGoogleFireBaseDbContext 
    {
        readonly string _projectId = "supergnisten-shoppinglist";
        public string CollectionKey { get; set; }

        public GoogleFireBaseDbContext()
        {
            //CollectionKey = collectionName;
            DB = FirestoreDb.Create(_projectId);
            //Collection = DB.Collection(CollectionKey);
        }
        public  CollectionReference Collection { get; set; }
        public FirestoreDb DB { get; private set; }

        //public string GetCollectionKey(object type)
        //{
        //    if (type is ShopItem sItem)
        //        return "shopitems";
        //    if (type is ItemCategory itemCat)
        //        return "itemcategories";
        //    if (type is ShoppingList lists)
        //        return "shoppinglists";
        //    return "otherDocuments"; 
        //}

        public string GetCollectionKey(Type toTypeGet)
        {
            if (toTypeGet == typeof(ShopItem))
                return "shopitems";
            if (toTypeGet == typeof(ItemCategory))
                return "itemcategories";
            if (toTypeGet == typeof(ShoppingList))
                return "shoppinglists";

            return "misc"; 
        }
    }    
}
