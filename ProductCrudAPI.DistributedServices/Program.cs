using ProductCrudAPI.Application.Services.Implementations;
using ProductCrudAPI.Application.Services.Interfaces;
using ProductCrudAPI.DistributedServices;
using ProductCrudAPI.Infrastructure.Repository;
using ProductCrudAPI.Infrastructure.Repository.Implementations;
using Serilog;
using ILogger = Serilog.ILogger;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(SwaggerConfiguration.AddSwaggerDocumentation);
builder.Services.AddSingleton<ILogger>(new LoggerConfiguration().WriteTo.Console().CreateLogger());
builder.Services.AddSingleton<IProductService, ProductService>();
builder.Services.AddSingleton<IProductRepository, ProductRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();