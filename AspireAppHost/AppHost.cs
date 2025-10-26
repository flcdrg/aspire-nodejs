using AspireAppHost;
using Microsoft.Extensions.Hosting;

var builder = DistributedApplication.CreateBuilder(args);

var nodeApp = builder.AddPnpmApp("pnpapp", "../NodeApp")
    // If you are using fnm for Node.js version management, you might need to adjust the PATH
    .WithEnvironment("PATH", Environment.GetEnvironmentVariable("PATH") + ";" + Environment.ExpandEnvironmentVariables(@"%USERPROFILE%\AppData\Roaming\fnm\aliases\default"))

    .WithHttpEndpoint(env: "PORT")
    .WithOtlpExporter()
    .WithHttpHealthCheck("/");

var launchProfile = builder.Configuration["DOTNET_LAUNCH_PROFILE"];

if (builder.Environment.IsDevelopment() && launchProfile == "https")
{
    nodeApp.RunWithHttpsDevCertificate("HTTPS_CERT_FILE", "HTTPS_CERT_KEY_FILE");
}

builder.Build().Run();
