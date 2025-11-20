var builder = DistributedApplication.CreateBuilder(args);

var postgres = builder
    .AddPostgres("postgres")
    .WithDataVolume("app-postgres-data")
    .AddDatabase("booksDb");

var apiService = builder
    .AddProject<Projects.BookStoreAspire_ApiService>("bookstore-api")
    .WithReference(postgres)
    .WaitFor(postgres)
    .WithHttpHealthCheck("/health");

builder
    .AddProject<Projects.BookStoreAspire_Web>("bookstore-web")
    .WithExternalHttpEndpoints()
    .WithHttpHealthCheck("/health")
    .WithReference(apiService)
    .WaitFor(apiService);

builder
    .Build()
    .Run();
