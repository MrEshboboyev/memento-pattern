namespace Domain.Models;

public class CartItem(string productName, decimal price, int quantity)
{
    public string ProductName { get; } = productName;
    public decimal Price { get; } = price;
    public int Quantity { get; } = quantity;
}
