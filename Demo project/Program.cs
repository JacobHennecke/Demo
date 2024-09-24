using Demo_project.Application.Services;
using Demo_project.Domain.Interfaces;
using Demo_project.Domain.Models;
using Demo_project.Infrastructure.DataSources;
using Demo_project.Infrastructure.Repositories;
using Demo_project.Middleware;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddScoped<IDataConnector<Asset>>(provider => new JsonDataSource<Asset>("Asset"));
builder.Services.AddScoped<IDataConnector<Briefing>>(provider => new JsonDataSource<Briefing>("Briefing"));
builder.Services.AddScoped<IDataConnector<ContentDistribution>>(provider => new JsonDataSource<ContentDistribution>("ContentDistribution"));

// Register repositories
builder.Services.AddScoped<IDataRepository<Asset, IEnumerable<Asset>>, AssetRepository>();
builder.Services.AddScoped<IDataRepository<Briefing, IEnumerable<Briefing>>, BriefingRepository>();
builder.Services.AddScoped<IDataRepository<ContentDistribution, ContentDistribution>, ContentDistributionRepository>();

// Register services
builder.Services.AddScoped<AssetService>();
builder.Services.AddScoped<BriefingService>();
builder.Services.AddScoped<ContentDistributionService>();

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

//app.UseHttpsRedirection();

//app.UseAuthorization();

app.MapControllers();

app.UseMiddleware<ExceptionMiddleware>();

var provider = new FileExtensionContentTypeProvider();
provider.Mappings[".obj"] = "application/wavefront-obj";

app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(
        Path.Combine(builder.Environment.ContentRootPath, "Assets")), 
        RequestPath = "/Assets",
        ContentTypeProvider = provider
});

JsonDataSource<Asset>.LoadDataFile(nameof(Asset));
JsonDataSource<Briefing>.LoadDataFile(nameof(Briefing));
JsonDataSource<ContentDistribution>.LoadDataFile(nameof(ContentDistribution));

app.MapGet("/", () => "Hello World!");

app.Run();

