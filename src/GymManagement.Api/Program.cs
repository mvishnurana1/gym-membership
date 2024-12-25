var builder = WebApplication.CreateBuilder(args);

// Manually call your Startup's ConfigureServices
var startup = new Startup(builder.Configuration);
startup.ConfigureServices(builder.Services);

var app = builder.Build();

// Manually call your Startup's Configure
startup.Configure(app, app.Environment);

app.Run();
