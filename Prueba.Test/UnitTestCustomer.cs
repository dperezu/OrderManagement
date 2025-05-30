using Microsoft.EntityFrameworkCore;
using OrderManagement.Domain.Entities;
using OrderManagement.Infrastructure;
using OrderManagement.Infrastructure.Repositories;

namespace OrderManagement.Tests.Repositories
{
    public class UnitTestCustomer
    {
        private AppDbContext GetDbContext()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()) 
                .Options;

            return new AppDbContext(options);
        }

        [Fact]
        public async Task AddAsync_Should_Add_Customer()
        {
            // Arrange
            var context = GetDbContext();
            var repository = new CustomerRepository(context);
            var customer = new Customer { Id = Guid.NewGuid(), Name = "John Doe" };

            // Act
            await repository.AddAsync(customer);
            await repository.SaveChangesAsync();

            // Assert
            var result = await context.Customers.FindAsync(customer.Id);
            Assert.NotNull(result);
            Assert.Equal("John Doe", result!.Name);
        }

        [Fact]
        public async Task GetAllAsync_Should_Return_Customers()
        {
            // Arrange
            var context = GetDbContext();
            context.Customers.Add(new Customer { Id = Guid.NewGuid(), Name = "jimena" });
            context.Customers.Add(new Customer { Id = Guid.NewGuid(), Name = "carlos" });
            await context.SaveChangesAsync();

            var repository = new CustomerRepository(context);

            // Act
            var result = await repository.GetAllAsync();

            // Assert
            Assert.Equal(2, result.Count());
        }

        [Fact]
        public async Task UpdateAsync_Should_Update_Customer()
        {
            // Arrange
            var context = GetDbContext();
            var customer = new Customer { Id = Guid.NewGuid(), Name = "prueba" };
            context.Customers.Add(customer);
            await context.SaveChangesAsync();

            var repository = new CustomerRepository(context);

            // Act
            customer.Name = "prueba1";
            await repository.UpdateAsync(customer);

            // Assert
            var updated = await context.Customers.FindAsync(customer.Id);
            Assert.Equal("prueba1", updated!.Name);
        }

        [Fact]
        public async Task DeleteAsync_Should_Remove_Customer()
        {
            // Arrange
            var context = GetDbContext();
            var customer = new Customer { Id = Guid.NewGuid(), Name = "eliminar" };
            context.Customers.Add(customer);
            await context.SaveChangesAsync();

            var repository = new CustomerRepository(context);

            // Act
            await repository.DeleteAsync(customer.Id);

            // Assert
            var deleted = await context.Customers.FindAsync(customer.Id);
            Assert.Null(deleted);
        }

        [Fact]
        public async Task GetByIdAsync_Should_Return_Customer()
        {
            // Arrange
            var context = GetDbContext();
            var customer = new Customer { Id = Guid.NewGuid(), Name = "jime" };
            context.Customers.Add(customer);
            await context.SaveChangesAsync();

            var repository = new CustomerRepository(context);

            // Act
            var result = await repository.GetByIdAsync(customer.Id);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("jime", result!.Name);
        }
    }
}

