using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Voitures.Shared.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddScoped(http => new HttpClient 
{
	BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) 
});

builder.Services.AddScoped<IVoitureService, ClientVoitureService>();
builder.Services.AddScoped<IEntretienService, ClientEntretienService>();

await builder.Build().RunAsync();
