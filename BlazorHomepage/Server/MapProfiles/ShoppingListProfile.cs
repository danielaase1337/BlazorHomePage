using AutoMapper;
using BlazorHomepage.Shared.Data.Entities;
using BlazorHomepage.Shared.Model.HandlelisteModels;

namespace BlazorHomepage.Server.MapProfiles
{
    public class ShoppingListProfile : Profile
    {
        public ShoppingListProfile()
        {
            CreateMap<ShoppingList, ShoppingListModel>().ReverseMap();
            CreateMap<ShoppingListItem, ShoppingListItemModel>().ReverseMap();
            CreateMap<ShopItem, ShopItemModel>().ReverseMap();
            CreateMap<ItemCategory, ItemCategoryModel>().ReverseMap();
            CreateMap<Shelf, ShelfModel>().ReverseMap();
        }
    }
}
