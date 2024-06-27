namespace ECommerceApp.Models;

public interface IDiscount
{
    decimal ApplyDiscount(decimal percentage);
}