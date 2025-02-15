using Application.Caretaker;
using Domain.Models;

namespace Infrastructure.Services;

public class CartService
{
    private readonly Cart _cart;
    private readonly CartCaretaker _caretaker;

    public CartService()
    {
        _cart = new Cart();
        _caretaker = new CartCaretaker();
    }

    public void AddItem(CartItem item)
    {
        _caretaker.SaveState(_cart.Save());
        _cart.AddItem(item);
    }

    public void RemoveItem(string productName)
    {
        _caretaker.SaveState(_cart.Save());
        _cart.RemoveItem(productName);
    }

    public void Undo()
    {
        var previousState = _caretaker.Undo();
        if (previousState != null)
        {
            _cart.Restore(previousState);
        }
        else
        {
            Console.WriteLine("⚠️ No previous cart state to restore.");
        }
    }

    public void ShowCart()
    {
        _cart.ShowCart();
    }
}
