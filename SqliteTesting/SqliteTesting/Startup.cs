using EntityFrameworkCore.LocalStorage;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;

namespace SqliteTesting
{
    public class Startup
    {
        public void ConfigureServices(IConfiguration configuration, IServiceCollection services, string baseAddress)
        {
            //https://docs.microsoft.com/en-us/aspnet/core/blazor/dependency-injection?view=aspnetcore-3.1
            services.AddDbContext<AppContext>(options =>
            {
                options.UseLocalStorageDatabase(services.GetJSRuntime(), databaseName: "db");
            }, ServiceLifetime.Transient);

            // //Spinner
            // services.AddScoped<ISpinnerService, SpinnerService>();
            // services.AddScoped<BlazorDisplaySpinnerAutomaticallyHttpMessageHandler>();
            //
            // //HttpClient Factory does not work with Client side blazor
            // services.AddTransient(sp => new HttpClient { BaseAddress = new Uri(baseAddress) });
        }
    }
}