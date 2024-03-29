﻿using BlazorHomepage.Shared.Model.HandlelisteModels;
using BlazorHomepage.Shared.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BlazorHomepage.Shared.MockData
{
    public class TempDataInit
    {
        public bool doneInit = false;
        public IEnumerable<ItemCategoryModel> AvailableCategories { get; set; }
        public IEnumerable<ShopItemModel> AvailableShopItems { get; set; }
        public IEnumerable<ShoppingListModel> AvailabelShoppingList { get; set; }
        public async Task InsertDefaultCategories(IGenericRepository<ItemCategoryModel> datamanger)
        {
            await datamanger.Insert(new ItemCategoryModel() { Name = "Meieri" });
            await datamanger.Insert(new ItemCategoryModel() { Name = "Brød" });
            await datamanger.Insert(new ItemCategoryModel() { Name = "Drikke" });
            await datamanger.Insert(new ItemCategoryModel() { Name = "Barnemat" });
            AvailableCategories = await datamanger.Get();
        }
        public async Task InsertDefaultShopItems(IGenericRepository<ShopItemModel> datamanager)
        {

            var catArr = AvailableCategories.ToArray();
            await datamanager.Insert(new ShopItemModel() { Name = "Melk", ItemCategory = catArr[0], Unit = "Liter" });
            await datamanager.Insert(new ShopItemModel() { Name = "Brød", ItemCategory = catArr[1], Unit = "Stk" });
            await datamanager.Insert(new ShopItemModel() { Name = "Øl", ItemCategory = catArr[2], Unit = "Stk" });
            await datamanager.Insert(new ShopItemModel() { Name = "Smoothi", ItemCategory = catArr[3], Unit = "Stk" });
            AvailableShopItems = await datamanager.Get();

        }
        public async Task InsertDefaultShoppingList(IGenericRepository<ShoppingListModel> datamanger)
        {
            doneInit = true;

            var shopItemArr = AvailableShopItems.ToArray();
            var shopListItems = new List<ShoppingListItemModel>()
        {
        new ShoppingListItemModel(){Varen = shopItemArr[0], Mengde  = 2, IsDone = false},
        new ShoppingListItemModel() { Varen = shopItemArr[1], Mengde = 1, IsDone = false },
        new ShoppingListItemModel() { Varen = shopItemArr[2], Mengde = 12, IsDone = false },
        new ShoppingListItemModel() { Varen = shopItemArr[3], Mengde = 2, IsDone = false }
                };


            await datamanger.Insert(
                new ShoppingListModel()
                {
                    Name = "Handleliste Uke 1",
                    IsDone = false,
                    ShoppingItems = shopListItems
                });
        }

        

    }
}
