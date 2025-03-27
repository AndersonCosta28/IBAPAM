var builder = DistributedApplication.CreateBuilder(args);

var cache = builder.AddRedis("cache");


var username = builder.AddParameter("username", "postgres", secret: true);
var password = builder.AddParameter("password", "postgres", secret: true);

var db = builder.AddPostgres("pgsql", username, password, 5432)
    .WithDataVolume("pg_data_volume", false)
    .AddDatabase("ibapamdb");

var apiService = builder.AddProject<Projects.IBAPAM_ApiService>("apiservice")
    .WithReference(db)
    .WaitFor(db);

builder.AddProject<Projects.IBAPAM_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithReference(cache)
    .WaitFor(cache)
    .WithReference(apiService)
    .WaitFor(apiService);

builder.Build().Run();
