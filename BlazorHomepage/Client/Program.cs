using BlazorHomepage.Client.DataManagers;
using BlazorHomepage.Shared.MockData;
using BlazorHomepage.Shared.Model;
using BlazorHomepage.Shared.Model.HandlelisteModels;
using BlazorHomepage.Shared.Repository;
using BlazorHomepage.Shared.UserData;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Syncfusion.Blazor;
using System.Reflection;

namespace BlazorHomepage.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NjYyMDgyQDMyMzAyZTMxMmUzMENBMmRUakJJSmVsWS81VXZrVVN3VXpvRnRjQllUV1ZiVUs1aXhYUVdlK289");

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
            
            builder.Services.AddSyncfusionBlazor();
            builder.Services.AddScoped<IGenericRepository<UserSettingsModel>, MemoryGenericRepository<UserSettingsModel>>();
            
            await builder.Build().RunAsync();
        }
    }
}
