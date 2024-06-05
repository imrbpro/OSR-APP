using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using MudBlazor.Services;
using OSR_APP.Services.Implementation;
using OSR_APP.Services.Interface;

namespace OSR_APP
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddTransient<IReadyService, ReadyService>();
            builder.Services.AddTransient<IDiscountingService, DiscountingService>();

            builder.Services.AddMudServices();
            await builder.Build().RunAsync();
        }
    }
}
