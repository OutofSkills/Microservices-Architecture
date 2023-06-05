using Microservice.Product.Models;
using Microsoft.EntityFrameworkCore;

namespace Microservices.Product.DataAccess
{
    public class ProductDbContext : DbContext
    {
        public DbSet<ProductModel> Products { get; set; }

        public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options)
        {
        }
    }
}
