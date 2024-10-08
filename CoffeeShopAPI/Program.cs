using CoffeeShopAPI.CoreModel;
using CoffeeShopAPI.Data;
using CoffeeShopAPI.Repositories.Interfaces;
using CoffeeShopAPI.Repositories.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<MilkTea2024Context>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("CoffeeShopAPI"));

});
// AutoMapper
builder.Services.AddAutoMapper(typeof(Mappers));

// register service
builder.Services.AddScoped<IProduct, ProductService>();
builder.Services.AddScoped<ICategory, CategoryService>();


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
