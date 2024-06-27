namespace ECommerceApp.Models;

public class ShoppingCart
{
    public List<Product> Products {get; set;}

    public ShoppingCart()
    {
        Products = new List<Product>();
    }
    
    public void AddProduct(Product productToAdd)
    {
        
        Products.Add(productToAdd);
    }

    public void RemoveProduct()
    {
        
    }

    public decimal CalculateTotalAmount()
    {
        decimal totalPrice = 0;
        foreach (var product in Products)
        {
            totalPrice += product.Price; // += assigns value and adds value
        }

        return totalPrice;
    }

}