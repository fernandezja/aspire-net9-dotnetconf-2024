using Starwars.App.Client.Pages;
using Starwars.App.Components;
using Starwars.App.DataServices;

var builder = WebApplication.CreateBuilder(args);

//Aspire
builder.AddServiceDefaults();
//builder.Services.AddHealthChecks();

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();


builder.AddRedisOutputCache("cacheredis");

// Register HttpClientFactory
builder.Services.AddHttpClient("StarwarsAPI", configureClient =>
{
    configureClient.BaseAddress = new Uri(builder.Configuration["Starwars:API:Url"] 
                                    ?? throw new InvalidOperationException("Starwars.API.Url configuration is missing."));

});

builder.Services.AddScoped<JediService>();


var app = builder.Build();


app.MapDefaultEndpoints();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseAntiforgery();

app.UseOutputCache();

app.MapStaticAssets();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(Starwars.App.Client._Imports).Assembly);

app.Run();
