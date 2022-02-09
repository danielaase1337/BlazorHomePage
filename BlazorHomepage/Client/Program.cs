using BlazorHomepage.Shared.Model;
using BlazorHomepage.Shared.Model.HandlelisteModels;
using BlazorHomepage.Shared.Repository;
using BlazorHomepage.Shared.UserData;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using System.Reflection;

namespace BlazorHomepage.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            //builder.Services.AddTransient(sp => new HttpClient { BaseAddress = new Uri("https://blazor-supergnisten-api.azurewebsites.net/") });
            //builder.Services.AddTransient(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

#if Debug
            builder.Services.AddTransient(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

#else
            builder.Services.AddTransient(sp => new HttpClient { BaseAddress = new Uri("https://blazor-supergnisten-api.azurewebsites.net/") });
#endif

            builder.Services.AddOidcAuthentication(options =>
            {
                builder.Configuration.Bind("Auth0", options.ProviderOptions);
                options.ProviderOptions.ResponseType = "code";
            });

            builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
            //builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            //Local repos
            builder.Services.AddScoped<IGenericRepository<User>, MemoryGenericRepository<User>>();




#if Debug
            builder.Services.AddScoped<IGenericRepository<ShoppingListModel>, MemoryGenericRepository<ShoppingListModel>>();
            builder.Services.AddScoped<IGenericRepository<ShopItemModel>, MemoryGenericRepository<ShopItemModel>>();
            builder.Services.AddScoped<IGenericRepository<ItemCategoryModel>, MemoryGenericRepository<ItemCategoryModel>>();
            builder.Services.AddScoped<IGenericRepository<ShopModel>, MemoryGenericRepository<ShopModel>>();
#else
            builder.Services.AddScoped<IGenericRepository<ShoppingListModel>, ShoppingListApiDataManager<ShoppingListModel>>();
            builder.Services.AddScoped<IGenericRepository<ShopItemModel>, ShopItemApiDataManagery<ShopItemModel>>();
            builder.Services.AddScoped<IGenericRepository<ItemCategoryModel>, ItemsCategoryApiDataManager<ItemCategoryModel>>();
            builder.Services.AddScoped<IGenericRepository<ShopModel>, ShopApiDataManager<ShopModel>>();
#endif
            //ApiRepos


            //builder.Services.AddScoped<IGenericRepository<ShelfModel>, MemoryGenericRepository<ShelfModel>>();

            builder.Services.AddScoped<IGenericRepository<UserSettingsModel>, MemoryGenericRepository<UserSettingsModel>>();
            await builder.Build().RunAsync();
        }
    }
}
