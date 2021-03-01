using BlazorHomepage.Shared.Model.GoogleModels;

namespace BlazorHomepage.Shared.Repository
{
    public class GoogleFireBaseShoppingListItemDbContext : GoogleFireBaseDbContext
    {
        public GoogleFireBaseShoppingListItemDbContext() : base(new ShoppingListCollectionModels())
        {

        }
    }

}
