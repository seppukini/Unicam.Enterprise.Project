using Unicam.Enterpise.Project.Application.Extensions;
using Unicam.Enterprise.Project.Extensions;
using Unicam.Enterprise.Project.Infrastructure.Extension;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddApplicationServices();
builder.Services.AddWebServices();

var app = builder.Build();

app.AddWebMiddleware();

app.Run();