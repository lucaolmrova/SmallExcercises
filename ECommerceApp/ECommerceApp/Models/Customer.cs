namespace ECommerceApp.Models;

public class Customer
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string Email { get; set; }

    public ShoppingCart ShoppingCart { get; set; }

    public Customer()
    {
        ShoppingCart = new ShoppingCart();
    }

   
}