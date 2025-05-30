using OrderManagement.Application;
using OrderManagement.Domain;
using OrderManagement.Infrastructure;
using OrderManagement.Infrastructure.Repositories;
using OrderManagement.Domain.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Register dependencies
builder.Services.AddScoped<IRepository, Repository>();
builder.Services.AddScoped<OrderManagement.Domain.DomainService>();
builder.Services.AddScoped<UseCase>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseInMemoryDatabase("AppDb"));

builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();
app.Run();
