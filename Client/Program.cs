using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using BlitzDMS.Client;
using BlitzDMS.Client.Services.CategoryGroupService;
using BlitzDMS.Client.Services.CategoryService;
using BlitzDMS.Client.Services.COAService;
using BlitzDMS.Client.Services.ItemService;
using BlitzDMS.Client.Services.UnitService;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddHttpClient("BlitzDMS.ServerAPI", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress))
    .AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();

// Supply HttpClient instances that include access tokens when making requests to the server project
builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("BlitzDMS.ServerAPI"));

builder.Services.AddApiAuthorization();
builder.Services.AddScoped<IntItemService, ItemService>();
builder.Services.AddScoped<ICategoryGroupService, CategoryGroupService>();
builder.Services.AddScoped<ICOAService, COAService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IUnitService, UnitService>();
await builder.Build().RunAsync();
