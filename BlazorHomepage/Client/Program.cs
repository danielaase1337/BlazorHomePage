using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Blazorise;
using Blazorise.Bootstrap;
using Blazorise.Icons.FontAwesome;
using BlazorHomepage.Client.DataManagers;
using BlazorHomepage.Shared.DataManagerModels;
using System.Reflection;
using BlazorHomepage.Shared.Model;
using BlazorHomepage.Shared.CovidHandlerData.Entities;
using BlazorHomepage.Shared.CovidHandlerData;
using BlazorHomepage.Shared.HandlelisteData;
using BlazorHomepage.Shared.Data.Entities;
using AutoMapper;
using BlazorHomepage.Shared.Model.CovidModels;
using BlazorHomepage.Shared.Model.HandlelisteModels;
using BlazorHomepage.Shared.Repository;
using BlazorHomepage.Shared.UserData;

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

            builder.Services.AddBlazorise(options =>
             {
                 options.ChangeTextOnKeyPress = true;
             })
      .AddBootstrapProviders()
      .AddFontAwesomeIcons();
            builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
            //builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            //StorageContextes Page handlers.. 
            //builder.Services.AddScoped<ICovidStorageContext<OneCovidContact> , CovidContactStorageContext>();
            //builder.Services.AddScoped<IStorageContext, ShoppingListLocalStorageContext>(); 

            //Local repos
            builder.Services.AddScoped<IGenericRepository<OneContactModel>, MemoryGenericRepository<OneContactModel>>();
            builder.Services.AddScoped<IGenericRepository<User>, MemoryGenericRepository<User>>();
            
            
            //builder.Services.AddScoped<IGenericRepository<ShoppingListModel>, MemoryGenericRepository<ShoppingListModel>>();
            //builder.Services.AddScoped<IGenericRepository<ShopItemModel>, MemoryGenericRepository<ShopItemModel>>();
            //builder.Services.AddScoped<IGenericRepository<ItemCategoryModel>, MemoryGenericRepository<ItemCategoryModel>>();
            //builder.Services.AddScoped<IGenericRepository<ShopModel>, MemoryGenericRepository<ShopModel>>();


            //ApiRepos
            //builder.Services.AddScoped<IGenericRepository<OneContactModel>, MemoryGenericRepository<OneContactModel>>();
            //builder.Services.AddScoped<IGenericRepository<User>, MemoryGenericRepository<User>>();

            builder.Services.AddScoped<IGenericRepository<ShoppingListModel>, ShoppingListApiDataManager<ShoppingListModel>>();
            builder.Services.AddScoped<IGenericRepository<ShopItemModel>, ShopItemApiDataManagery<ShopItemModel>>();
            builder.Services.AddScoped<IGenericRepository<ItemCategoryModel>, ItemsCategoryApiDataManager<ItemCategoryModel>>();
            builder.Services.AddScoped<IGenericRepository<ShopModel>, ShopApiDataManager<ShopModel>>();
            builder.Services.AddBlazorise(options =>
            {
                options.ChangeTextOnKeyPress = true;
            })
                .AddBootstrapProviders()
                .AddFontAwesomeIcons();

            //builder.Services.AddScoped<IGenericRepository<ShelfModel>, MemoryGenericRepository<ShelfModel>>();

            builder.Services.AddScoped<IGenericRepository<UserSettingsModel>, MemoryGenericRepository<UserSettingsModel>>();
            await builder.Build().RunAsync();
        }
    }
}
