using Microsoft.AspNetCore.Mvc;
using OrderManagement.Domain.Repository;
using OrderManagement.Domain;

namespace OrderManagement.Presentation.Controllers;

/// <summary>
/// Clase que permite hacer la gestion del cliente
/// </summary>
[ApiController]
[Route("api/[controller]")]

public class CustomerController : ControllerBase
{
    private readonly ICustomerRepository _repository;

    public CustomerController(ICustomerRepository repository)
    {
        _repository = repository;
    }

    /// <summary>
    /// Metodo que permite obtener todos los clientes 
    /// </summary>
    /// <returns>clientes</returns>
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
