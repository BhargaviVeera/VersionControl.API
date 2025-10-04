using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Version190925.API.Repositories.Interfaces;
using Version190925.API.Repositories.Version190925;
using Version210926.API.Repositories.Interfaces;
using Version210926.API.Repositories.Version210926;


var builder = WebApplication.CreateBuilder(args);

// Add controllers
builder.Services.AddControllers();

builder.Services.AddSingleton<Version210926.API.Repositories.Interfaces.IRegionRepository, Version210926.API.Repositories.Version210926.RegionRepository>();

builder.Services.AddSingleton<Version190925.API.Repositories.Interfaces.IExtendedRegionRepository, Version190925.API.Repositories.Version190925.RegionRepository>();

// Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Swagger in Development
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Middleware
app.UseHttpsRedirection();
app.UseAuthorization();

// Map controllers
app.MapControllers();

app.Run();
