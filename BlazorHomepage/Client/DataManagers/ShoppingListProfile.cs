using AutoMapper;
using BlazorHomepage.Shared.Data.Entities;
using BlazorHomepage.Shared.Model.HandlelisteModels;

namespace BlazorHomepage.Client.DataManagers
{
    public class ShoppingListProfile : Profile
    {
        public ShoppingListProfile()
        {
            this.CreateMap<ShoppingList, ShoppingListModel>();
            this.CreateMap<ShoppingListItem, ShoppingListItemModel>();
            this.CreateMap<ShopItem, ShopItemModel>();
            this.CreateMap<Shelf, ShelfModel>();
            this.CreateMap<ItemCategory, ItemCategoryModel>();
        }
    }
}
