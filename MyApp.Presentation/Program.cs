using MyApp.Application;
using Prueba.Domain;
using MyApp.Infrastructure;
using MyApp.Infrastructure.Repositories;
using Prueba.Domain.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Register dependencies
builder.Services.AddScoped<IRepository, Repository>();
builder.Services.AddScoped<Prueba.Domain.DomainService>();
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
