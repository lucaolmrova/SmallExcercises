using ECommerceApp.Models;

namespace ECommerceApp.Services;

public class ProductService
{
    private List<Product> products;
    
    public ProductService()
    {
        products = new List<Product>
        {
            new Product { Id = 1, Name = "Laptop", Price = 1000, Stock = 1 },
            new Product { Id = 2, Name = "Smartphone", Price = 700, Stock = 1 },
            new Product { Id = 3, Name = "Tablet", Price = 300, Stock = 1 }
        };
    }

    public List<Product> GetAllProducts()
    {
        return products;
    }

    public Product GetProductById(int id)
    {
        return products.First(p => p.Id == id);
    }

    public void DecreaseStock(int id)
    {
        var product = GetProductById(id);
        product.Stock = product.Stock - 1;
        if (product.Stock == 0)
        {
            RemoveProductById(product.Id);
        }
    }

    public void RemoveProductById(int id)
    {
        var product = GetProductById(id);
        products.Remove(product);
    }
    
    public void ApplyDiscount(int id, decimal percentage)
    {
        var product = GetProductById(id);
        if (product != null)
        {
            product.Price = product.ApplyDiscount(percentage);
        }
    }
}