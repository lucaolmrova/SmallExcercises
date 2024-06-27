namespace ECommerceApp.Models;

public class Order
{
    public int Id { get; set; }
    
    public Customer Customer { get; set; }
    
    public List<Product> Products { get; set; }
    
    public decimal TotalAmount { get; set; }
    
    public DateTime OrderDate { get; set; }

    public Order(List<Product> products, Customer customer)  //constructor
    {
        Customer = customer;
        Products =  products;
        OrderDate = DateTime.Now;
        TotalAmount = products.Sum(p => p.Price);   //also possible to write like this: TotalAmount = customer.ShoppingCart.CalculateTotalAmount();
    }
}