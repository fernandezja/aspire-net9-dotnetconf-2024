var builder = DistributedApplication.CreateBuilder(args);

var cacheredis = builder.AddRedis("cache-redis")
                        .WithImageTag("alpine");


var starwarsapi = builder.AddProject<Projects.Starwars_Api>("starwars-api")
                    .WithReference(cacheredis)
                    .WaitFor(cacheredis); ;

builder.AddProject<Projects.Starwars_App>("starwars-app")
       .WithExternalHttpEndpoints() //Azure App Service publico
       .WithReference(starwarsapi)
       .WaitFor(starwarsapi) 
       .WithReference(cacheredis)
       .WaitFor(cacheredis);

builder.Build().Run();
