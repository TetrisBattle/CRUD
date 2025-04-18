using Api.Setup;

var builder = WebApplication.CreateBuilder(args);

Setup.SetupServices(builder);

var app = builder.Build();

Setup.SetupApp(app);

await Setup.SetupDatabase(app.Services);

app.Run();
