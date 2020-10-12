using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Radzen;

namespace SqliteTesting
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            new Startup().ConfigureServices(builder.Configuration, builder.Services, builder.HostEnvironment.BaseAddress);
            builder.RootComponents.Add<App>("app");

            var host = builder.Build();

            //Seed Data
            using (var scope = host.Services.CreateScope())
            {
                using var context = scope.ServiceProvider.GetService<AppContext>();
                await context.Database.EnsureCreatedAsync();
            }
            
            builder.Services.AddScoped(
                sp => new HttpClient {BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)});
                builder.Services.AddScoped<DialogService>();
                builder.Services.AddScoped<NotificationService>();
                builder.Services.AddScoped<TooltipService>();
                builder.Services.AddScoped<ContextMenuService>();
            await builder.Build().RunAsync();
        }
    }
}