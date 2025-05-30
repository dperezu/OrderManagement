using Microsoft.AspNetCore.Mvc;
using MyApp.Application;
using Prueba.Domain.Repository;
using Prueba.Domain;

namespace MyApp.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]

public class CustomerController : ControllerBase
{
    private readonly ICustomerRepository _repository;

    public CustomerController(ICustomerRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var customers = await _repository.GetAllAsync();
        return Ok(customers);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] Customer customer)
    {
        await _repository.AddAsync(customer);
        await _repository.SaveChangesAsync();
        return CreatedAtAction(nameof(GetAll), new { id = customer.Id }, customer);
    }
}
