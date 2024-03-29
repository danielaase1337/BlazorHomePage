using BlazorHomepage.Shared.Data.Entities;
using BlazorHomepage.Shared.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Reflection;

namespace BlazorHomepage.Server
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllersWithViews();
            services.AddRazorPages();
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddScoped<IGenericRepository<ShoppingList>, GoogleFirebaseGenenricRepository<ShoppingList>>();
            services.AddScoped<IGenericRepository<ShopItem>, GoogleFirebaseGenenricRepository<ShopItem>>();
            services.AddScoped<IGenericRepository<ItemCategory>, GoogleFirebaseGenenricRepository<ItemCategory>>();
            services.AddScoped<IGenericRepository<Shop>, GoogleFirebaseGenenricRepository<Shop>>();

            services.AddScoped<IGoogleFireBaseDbContext, GoogleFireBaseDbContext>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            //app.UseCors(options => options.WithOrigins("http://handleliste.aase-broen.net").AllowAnyMethod().AllowAnyHeader());
            app.UseCors(options => options.WithOrigins("*").AllowAnyMethod().AllowAnyHeader());

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseWebAssemblyDebugging();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }


            var configBuilder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables(prefix: "MyEnvVars_");
            var config = configBuilder.Build();
            
            

            app.UseHttpsRedirection();
            app.UseBlazorFrameworkFiles();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllers();
                endpoints.MapFallbackToFile("index.html");
            });
        }
    }
}
