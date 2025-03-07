﻿using MementoPatternInConsole.Mementos;
using MementoPatternInConsole.Mementos.Concrets;

namespace MementoPatternInConsole;

// The Originator holds some important state that may change over time. It also
// defines a method for saving the state inside a memento and another method for
// restoring the state from it.
public class Originator
{
    // For the sake of simplicity, the originator's state is stored inside a single
    // variable.
    private string _state;

    public Originator(string state)
    {
        _state = state;
        Console.WriteLine($"Originator: My initial state is: {_state}");
    }

    // The Originator's business logic may affect its internal state. Therefore, the
    // client should backup the state before launching methods of the business logic
    // via the save() method.
    public void DoSomething()
    {
        Console.WriteLine("Originator: I'm doing something important.");
        _state = GenerateRandomString(30);
        Console.WriteLine($"Originator: and my state has changed to: {_state}");
    }

    private string GenerateRandomString(int length = 10)
    {
        string allowedSymbols = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
        string result = string.Empty;
        Random random = new Random();
        for (int i = 0; i < length; i++)
        {
            result += allowedSymbols[random.Next(0, allowedSymbols.Length)];
        }
        return result;
    }

    // Saves the current state inside a memento.
    public IMemento Save()
    {
        return new ConcreteMemento(_state);
    }

    // Restores the Originator's state from a memento object.
    public void Restore(IMemento memento)
    {
        if (!(memento is ConcreteMemento))
        {
            throw new Exception("Unknown memento class " + memento.ToString());
        }
        _state = memento.GetState();
        Console.WriteLine($"Originator: My state has changed to: {_state}");
    }
}
