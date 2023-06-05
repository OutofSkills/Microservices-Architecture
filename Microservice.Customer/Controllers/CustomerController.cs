using Microservice.Customer.Models;
using Microservices.Customer.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Microservices.Customer.Controllers;

[Route("api/customers")]
[ApiController]
public class CustomerController : ControllerBase
{
    private readonly ICustomerRepository _customerRepository;

    public CustomerController(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    // GET api/customers
    [HttpGet]
    public IActionResult GetCustomers()
    {
        var customers = _customerRepository.GetAllCustomers();
        return Ok(customers);
    }

    // GET api/customers/{id}
    [HttpGet("{id}")]
    public IActionResult GetCustomer(int id)
    {
        var customer = _customerRepository.GetCustomerById(id);
        if (customer == null)
        {
            return NotFound();
        }
        return Ok(customer);
    }

    // POST api/customers
    [HttpPost]
    public IActionResult CreateCustomer([FromBody] CustomerModel customer)
    {
        _customerRepository.AddCustomer(customer);
        return CreatedAtAction(nameof(GetCustomer), new { id = customer.Id }, customer);
    }

    // PUT api/customers/{id}
    [HttpPut("{id}")]
    public IActionResult UpdateCustomer(int id, [FromBody] CustomerModel customer)
    {
        var existingCustomer = _customerRepository.GetCustomerById(id);
        if (existingCustomer == null)
        {
            return NotFound();
        }
        customer.Id = id; // Ensure the ID is set
        _customerRepository.UpdateCustomer(customer);
        return NoContent();
    }

    // DELETE api/customers/{id}
    [HttpDelete("{id}")]
    public IActionResult DeleteCustomer(int id)
    {
        var existingCustomer = _customerRepository.GetCustomerById(id);
        if (existingCustomer == null)
        {
            return NotFound();
        }
        _customerRepository.DeleteCustomer(id);
        return NoContent();
    }
}
