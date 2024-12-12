using Starwars.Core.Business;
using Starwars.Core.Business.Interfaces;
using Starwars.Core.Data;
using Starwars.Core.Data.Interfaces;
using Starwars.Core.Entities;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

//Aspire
builder.AddServiceDefaults();

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
//builder.Services.AddHealthChecks();

builder.Services.AddScoped<IJediRepository, JediRepository>();
builder.Services.AddScoped<IJediBusiness, JediBusiness>();

var app = builder.Build();


app.MapDefaultEndpoints();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapGet("/api/jedi", (IJediBusiness jediBusiness) =>
{
    return jediBusiness.GetAllAsync();
})
.WithName("GetJedis");

app.Run();
