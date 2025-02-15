using Domain.Mementos;

namespace Application.Caretaker;

public class CartCaretaker
{
    private readonly Stack<CartMemento> _history = new();

    public void SaveState(CartMemento memento)
    {
        _history.Push(memento);
    }

    public CartMemento Undo()
    {
        if (_history.Count > 0)
        {
            return _history.Pop();
        }
        return null!;
    }
}
