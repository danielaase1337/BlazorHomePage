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

namespace BlazorHomepage.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            


            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.Services.AddBlazorise(options =>
             {
                 options.ChangeTextOnKeyPress = true;
             })
      .AddBootstrapProviders()
      .AddFontAwesomeIcons();
            builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            
            //StorageContextes Page handlers.. 
            builder.Services.AddScoped<ICovidStorageContext<OneCovidContact> , CovidContactStorageContext>();
            builder.Services.AddScoped<IShoppingListStorageContext<ShoppingList>, ShoppingListLocalStorageContext>(); 
            
            //Datamangere AKA API handlers. 
            builder.Services.AddScoped<ICovidContactsDataManager, CovidContactsLocalDataManager>();
            builder.Services.AddScoped<IUserDataManager<User>, LocalUserDataManager>();
            builder.Services.AddScoped<IShoppingListDataManager, ShoppingListLocalDataManager>(); 
            
            var host = builder.Build();

            host.Services
      .UseBootstrapProviders()
      .UseFontAwesomeIcons();
            await host.RunAsync();
        }
    }
}
