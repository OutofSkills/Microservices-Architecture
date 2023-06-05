using Microservice.Customer.Models;
using Microservices.Customer.DataAccess;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Microservices.Customer.Repositories;

public class CustomerRepository : ICustomerRepository
{
    private readonly CustomerDbContext _context;

    public CustomerRepository(CustomerDbContext context)
    {
        _context = context;
    }

    public IEnumerable<CustomerModel> GetAllCustomers()
    {
        return _context.Set<CustomerModel>().ToList();
    }

    public CustomerModel? GetCustomerById(int id)
    {
        return _context.Set<CustomerModel>().Find(id);
    }

    public void AddCustomer(CustomerModel customer)
    {
        _context.Set<CustomerModel>().Add(customer);
        _context.SaveChanges();
    }

    public void UpdateCustomer(CustomerModel customer)
    {
        _context.Entry(customer).State = EntityState.Modified;
        _context.SaveChanges();
    }

    public void DeleteCustomer(int id)
    {
        var customer = _context.Set<CustomerModel>().Find(id);
        if (customer != null)
        {
            _context.Set<CustomerModel>().Remove(customer);
            _context.SaveChanges();
        }
    }
}

