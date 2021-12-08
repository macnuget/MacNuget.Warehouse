using MacNuget.Warehouse.ApplicationCore.Interfaces.Repositories;
using MacNuget.Warehouse.ApplicationCore.Interfaces.Services;
using MacNuget.Warehouse.ApplicationCore.Services;
using MacNuget.Warehouse.Infrastructure.Repositories;

RepoDb.PostgreSqlBootstrap.Initialize();

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IProductsService,     ProductsService>    ();
builder.Services.AddScoped<ISuppliersService,    SuppliersService>   ();
builder.Services.AddScoped<IRefillsService,      RefillsService>     ();
builder.Services.AddScoped<IProductsRepository,  ProductsRepository> ();
builder.Services.AddScoped<ISuppliersRepository, SuppliersRepository>();
builder.Services.AddScoped<IRefillsRepository,   RefillsRepository>  ();

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
