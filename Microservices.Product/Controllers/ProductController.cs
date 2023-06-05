using Microservice.Product.Models;
using Microservices.Product.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Microservice.Product.Controllers;

[Route("api/products")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly IProductRepository _productRepository;

    public ProductController(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    // GET api/products
    [HttpGet]
    public IActionResult GetProducts()
    {
        var products = _productRepository.GetAllProducts();
        return Ok(products);
    }

    // GET api/products/{id}
    [HttpGet("{id}")]
    public IActionResult GetProduct(int id)
    {
        var product = _productRepository.GetProductById(id);
        if (product == null)
        {
            return NotFound();
        }
        return Ok(product);
    }

    // POST api/products
    [HttpPost]
    public IActionResult CreateProduct([FromBody] ProductModel product)
    {
        _productRepository.AddProduct(product);
        return CreatedAtAction(nameof(GetProduct), new { id = product.Id }, product);
    }

    // PUT api/products/{id}
    [HttpPut("{id}")]
    public IActionResult UpdateProduct(int id, [FromBody] ProductModel product)
    {
        var existingProduct = _productRepository.GetProductById(id);
        if (existingProduct == null)
        {
            return NotFound();
        }
        product.Id = id; // Ensure the ID is set
        _productRepository.UpdateProduct(product);
        return NoContent();
    }

    // DELETE api/products/{id}
    [HttpDelete("{id}")]
    public IActionResult DeleteProduct(int id)
    {
        var existingProduct = _productRepository.GetProductById(id);
        if (existingProduct == null)
        {
            return NotFound();
        }
        _productRepository.DeleteProduct(id);
        return NoContent();
    }
}
