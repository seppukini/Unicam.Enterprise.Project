using Unicam.Enterprise.Project.Application.Extensions;
using Unicam.Enterprise.Project.Extensions;
using Unicam.Enterprise.Project.Infrastructure.Extension;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddApplicationServices();
builder.Services.AddWebServices(builder.Configuration);

var app = builder.Build();

app.AddWebMiddleware();

app.Run();