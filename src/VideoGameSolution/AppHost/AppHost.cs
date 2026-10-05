using Scalar.Aspire;

var builder = DistributedApplication.CreateBuilder(args);

var openApiViewer = builder.AddScalarApiReference(options =>
{
    options.PreferHttpsEndpoint = true;
    options.AllowSelfSignedCertificates = true;
}).WithLifetime(ContainerLifetime.Persistent);




var api = builder.AddProject<Projects.Games_Api>("games-api");

openApiViewer.WithApiReference(api);

var app = builder.Build();
app.Run();
