using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Prueba.Domain;

namespace MyApp.Infrastructure;

public class AppDbContext : DbContext
{
    public DbSet<Customer> Customers => Set<Customer>();
    public DbSet<Order> Orders => Set<Order>();

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
}
