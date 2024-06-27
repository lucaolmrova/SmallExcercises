using ECommerceApp.Models;
using ECommerceApp.Services;

namespace ECommerceApp;

class Program
{
    static void Main(string[] args)
    {
        var productService = new ProductService();
        var customerService = new CustomerService();
        var orderService = new OrderService(productService, customerService);

        while (true)
        {
            Console.WriteLine("1. View Products");
            Console.WriteLine("2. View Customers");
            Console.WriteLine("3. Add Product to Cart");
            Console.WriteLine("4. View Cart");
            Console.WriteLine("5. Create Order from Cart");
            Console.WriteLine("6. Apply Discount to Product");
            Console.WriteLine("7. View Orders");
            Console.WriteLine("8. Exit");
            Console.Write("Please enter your choice: ");
            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    var products = productService.GetAllProducts();
                     
                    foreach (var product in products)
                    {
                        Console.WriteLine($"ID: {product.Id}, Name: {product.Name}, Price: {product.Price}, Stock: {product.Stock}");
                    }
                    break;
                case"2":
                    var customers = customerService.GetAllCustomers();
                    
                    foreach (var customer in customers)
                    {
                        Console.WriteLine($"ID: {customer.Id}, Name: {customer.Name}, Email: {customer.Email}");
                    }
                    break;
                case "3":
                    Console.WriteLine("Write customer id:");
                    int customerId = int.Parse(Console.ReadLine());
                    var shoppingCustomer = customerService.GetCustomerById(customerId);
                    Console.WriteLine("Write product id:");
                    int productId = int.Parse(Console.ReadLine());
                    var productToAdd = productService.GetProductById(productId);
                    productService.DecreaseStock(productId);
                    shoppingCustomer.ShoppingCart.AddProduct(productToAdd);
                    break;
                case "4":
                    Console.WriteLine("Write customer id:");
                    int shoppingCartCustomerId = int.Parse(Console.ReadLine());
                    var shoppingCartCustomer = customerService.GetCustomerById(shoppingCartCustomerId);
                    foreach (var product in shoppingCartCustomer.ShoppingCart.Products)
                    {
                        Console.WriteLine($"ID: {product.Id}, Name: {product.Name}, Price: {product.Price}");

                    }
                    decimal totalPrice = shoppingCartCustomer.ShoppingCart.CalculateTotalAmount();
                    Console.WriteLine($"Total price is {totalPrice}");
                    break;
                case "5":
                    Console.WriteLine("Write customer id:");
                    int orderCustomerId = int.Parse(Console.ReadLine());
                    orderService.CreateOrder(orderCustomerId);
                    break;
                case "6":
                    break;
                case "7":
                    var orders = orderService.GetAllOrders();
                     
                    foreach (var order in orders)
                    {
                        Console.WriteLine($"Order ID: {order.Id}, Customer: {order.Customer.Name}, Total Amount: {order.TotalAmount}, Order Date: {order.OrderDate}");
                        foreach (var orderProduct in order.Products)
                        {
                            Console.WriteLine($"\tProduct: {orderProduct.Name}, Price: {orderProduct.Price}");
                        }
                    }
                    break;
                case "8":
                    break;
                    
            }
        }
    }
}