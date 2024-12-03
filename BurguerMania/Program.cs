using Microsoft.EntityFrameworkCore;
using BurguerManiaAPI.Context;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using Microsoft.AspNetCore.Mvc;

using BurguerManiaAPI.Services.User;
using BurguerManiaAPI.Services.UserOrder;
using BurguerManiaAPI.Services.Product;
using BurguerManiaAPI.Services.Category;
using BurguerManiaAPI.Services.Order;
using BurguerManiaAPI.Services.OrderProduct;

using BurguerManiaAPI.Interfaces.User;
using BurguerManiaAPI.Interfaces.UserOrder;
using BurguerManiaAPI.Interfaces.Product;
using BurguerManiaAPI.Interfaces.Category;
using BurguerManiaAPI.Interfaces.Order;
using BurguerManiaAPI.Interfaces.OrderProduct;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers() 
    .ConfigureApiBehaviorOptions(options =>
    {   // limita a resposta de error 400
        options.InvalidModelStateResponseFactory = context =>
        {
            var errors = context.ModelState
                .Where(e => e.Value != null && e.Value.Errors.Count > 0)
                .ToDictionary(
                    kvp => kvp.Key,
                    kvp => kvp.Value?.Errors.Select(x => x.ErrorMessage).ToArray() ?? Array.Empty<string>()
                );

            var result = new
            {
                status = 400,
                errors = errors
            };

            return new BadRequestObjectResult(result);
        };
    });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IUserInterface, UserService>();
builder.Services.AddScoped<IUserOrderInterface, UserOrderService>();
builder.Services.AddScoped<IProductInterface, ProductService>();
builder.Services.AddScoped<ICategoryInterface, CategoryService>();
builder.Services.AddScoped<IOrderInterface, OrderService>();
builder.Services.AddScoped<IOrderProductInterface, OrderProductService>();


// Configure MySQL connection string
string? mySqlConnectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Register DbContext with MySQL
builder.Services.AddDbContext<AppDbContext>(options => 
    options.UseMySql(mySqlConnectionString, ServerVersion.AutoDetect(mySqlConnectionString)));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseSwagger();
app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1"));

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();