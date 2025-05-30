using Microsoft.AspNetCore.Mvc;
using OrderManagement.Domain.Repository;
using OrderManagement.Domain.Entities;
using OrderManagement.Infrastructure.Repositories;

namespace OrderManagement.Presentation.Controladores;

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
    /// <summary>
    /// Metodo que permite crear un cliente
    /// </summary>
    /// <param name="customer"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] Customer customer)
    {
        await _repository.AddAsync(customer);
        await _repository.SaveChangesAsync();
        return CreatedAtAction(nameof(GetAll), new { id = customer.Id }, customer);
    }
    /// <summary>
    /// Actualiza un cliente existente.
    /// </summary>
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] Customer customer)
    {
        if (id != customer.Id)
            return BadRequest("ID del cliente no coincide con el de la ruta.");

        await _repository.UpdateAsync(customer);
        return NoContent();
    }

    /// <summary>
    /// Elimina un cliente por ID.
    /// </summary>
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _repository.DeleteAsync(id);
        return NoContent();
    }
}
