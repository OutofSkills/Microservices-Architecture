using Microservice.Product.Models;
using Microservices.Product.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace Microservices.Product.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly ProductDbContext _context;

    public ProductRepository(ProductDbContext context)
    {
        _context = context;
    }

    public IEnumerable<ProductModel> GetAllProducts()
    {
        return _context.Set<ProductModel>().ToList();
    }

    public ProductModel? GetProductById(int id)
    {
        return _context.Set<ProductModel>().Find(id);
    }

    public void AddProduct(ProductModel product)
    {
        _context.Set<ProductModel>().Add(product);
        _context.SaveChanges();
    }

    public void UpdateProduct(ProductModel product)
    {
        _context.Entry(product).State = EntityState.Modified;
        _context.SaveChanges();
    }

    public void DeleteProduct(int id)
    {
        var product = _context.Set<ProductModel>().Find(id);
        if (product != null)
        {
            _context.Set<ProductModel>().Remove(product);
            _context.SaveChanges();
        }
    }
}

