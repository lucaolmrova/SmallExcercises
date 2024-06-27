using ECommerceApp.Models;

namespace ECommerceApp.Services;

public class OrderService
{
    private List<Order> orders;
    private readonly ProductService productService;
    private readonly CustomerService customerService;

    public OrderService(ProductService productService, CustomerService customerService)   //constructor
    {
        orders = new List<Order>();
        this.productService = productService; //getting instance from the constructor variable on line 11, assigning the value to the productService on line 8
        this.customerService = customerService;
    }
    
    public void CreateOrder(int customerId)
    {
        var customer = customerService.GetCustomerById(customerId);
        var shoppingCart = customer.ShoppingCart;
        var order = new Order(shoppingCart.Products, customer);
        orders.Add(order);
    }

    public List<Order> GetAllOrders()
    {
        return orders;
    }
}