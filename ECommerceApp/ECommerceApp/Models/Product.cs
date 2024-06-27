namespace ECommerceApp.Models;

public class Product : IDiscount
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public int Stock { get; set; }
    
    public decimal ApplyDiscount(decimal percentage)
    {
        return Price - (Price * percentage / 100);
    }
}