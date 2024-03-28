using Unicam.Paradigmi.Project.Application.Extensions;
using Unicam.Paradigmi.Project.Extensions;
using Unicam.Paradigmi.Project.Infrastructure.Extension;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddApplicationServices();
builder.Services.AddWebServices();

var app = builder.Build();

app.AddWebMiddleware();

app.Run();