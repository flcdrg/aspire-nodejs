var builder = DistributedApplication.CreateBuilder(args);

var nodeApp = builder.AddJavaScriptApp("pnpapp", "../NodeApp")
    .WithPnpm()
    .WithRunScript("start")
    // If you are using fnm for Node.js version management, you might need to adjust the PATH
    .WithEnvironment("PATH", Environment.GetEnvironmentVariable("PATH") + ";" + Environment.ExpandEnvironmentVariables(@"%USERPROFILE%\AppData\Roaming\fnm\aliases\default"))

    .WithHttpEndpoint(env: "PORT")
    .WithOtlpExporter()
    .WithHttpHealthCheck("/");

builder.Build().Run();
