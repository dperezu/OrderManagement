using OrderManagement.Infrastructure;
using OrderManagement.Infrastructure.Repositories;
using OrderManagement.Domain.Repository;
using Microsoft.EntityFrameworkCore;
using OrderManagement.Application.Services;

var builder = WebApplication.CreateBuilder(args);

// Register dependencies

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSwaggerGen(options =>
{
    var xmlFilename = $"{System.Reflection.Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseInMemoryDatabase("AppDb"));

builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<IOrderService, OrderService>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();
app.Run();
