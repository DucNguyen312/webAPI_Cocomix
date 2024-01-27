using Cocomix_API.Models;
using Cocomix_API.Service;
using Cocomix_API.Service.ServiceIMPL;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<QLCHContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("Mydb"));
});



builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddScoped<ProductService, ProductServiceIMPL>();
builder.Services.AddScoped<CategoryService, CategoryServiceIMPL>();
builder.Services.AddScoped<CustomerService, CustomerServiceIMPL>();

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
