using ECommerceApp.Models;

namespace ECommerceApp.Services;

public class CustomerService
{
    private List<Customer> customers;

    public CustomerService()
    {
        customers = new List<Customer>
        {
            new Customer { Id = 1, Name = "John Doe", Email = "john@example.com" },
            new Customer { Id = 2, Name = "Jane Smith", Email = "jane@example.com" }
        };
    }
    
    public List<Customer> GetAllCustomers()
    {
        return customers;
    }

    public Customer GetCustomerById(int id)
    {
        return customers.First(c => c.Id == id);
    }
}