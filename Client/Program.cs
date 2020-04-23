using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using PizzaPlace.Shared;
using PizzaPlace.Client.Services;

namespace PizzaPlace.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            builder.Services.AddBaseAddressHttpClient();
            builder.Services.AddTransient<IMenuService, MenuService>();
            builder.Services.AddTransient<IOrderService, OrderService>();
            builder.Services.AddSingleton<State>();

            await builder.Build().RunAsync();
        }
    }
}
