﻿namespace Microservice.Customer.Models;

public class CustomerModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Address { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string ZipCode { get; set; }
    public DateTime DateOfBirth { get; set; }
    public bool IsActive { get; set; }
    public decimal Balance { get; set; }
}

