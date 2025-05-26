var builder = DistributedApplication.CreateBuilder(args);

var apiService = builder.AddProject<Projects.BowlingConcept_ApiService>("apiservice");

builder.AddProject<Projects.BowlingConcept_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithReference(apiService)
    .WaitFor(apiService);

builder.Build().Run();
