using Domain.Models;

namespace Domain.Mementos;

public class CartMemento(List<CartItem> items)
{
    private readonly List<CartItem> _savedItems = [.. items];

    public List<CartItem> GetSavedItems()
    {
        return [.. _savedItems];
    }
}
