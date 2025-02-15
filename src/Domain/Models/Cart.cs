using Domain.Mementos;

namespace Domain.Models;

public class Cart
{
    private List<CartItem> _items = [];

    public void AddItem(CartItem item)
    {
        _items.Add(item);
        Console.WriteLine($"✅ Added {item.ProductName} to cart.");
    }

    public void RemoveItem(string productName)
    {
        _items = _items.Where(i => i.ProductName != productName).ToList();
        Console.WriteLine($"❌ Removed {productName} from cart.");
    }

    public void ShowCart()
    {
        Console.WriteLine("\n🛒 Current Cart:");
        foreach (var item in _items)
        {
            Console.WriteLine($"- {item.ProductName} (${item.Price}) x {item.Quantity}");
        }
    }

    public CartMemento Save()
    {
        return new CartMemento([.. _items]);
    }

    public void Restore(CartMemento memento)
    {
        _items = memento.GetSavedItems();
        Console.WriteLine("🔄 Cart restored to previous state.");
    }
}
