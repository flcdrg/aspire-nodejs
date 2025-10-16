var builder = DistributedApplication.CreateBuilder(args);

builder.AddNpmApp("nodeapp", "../NodeApp")
    .WithHttpEndpoint(env: "PORT");

builder.AddPnpmApp("pnpapp", "../NodeApp")
    .WithHttpEndpoint(env: "PORT")
    .WithHttpHealthCheck("/");

builder.Build().Run();
