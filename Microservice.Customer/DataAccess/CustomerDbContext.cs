using Microservice.Customer.Models;
using Microsoft.EntityFrameworkCore;

namespace Microservices.Customer.DataAccess
{
    public class CustomerDbContext : DbContext
    {
        public DbSet<CustomerModel> Customers { get; set; }

        public CustomerDbContext(DbContextOptions<CustomerDbContext> options) : base(options)
        {
        }
    }
}
