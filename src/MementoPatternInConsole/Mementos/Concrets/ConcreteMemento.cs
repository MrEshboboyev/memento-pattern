namespace MementoPatternInConsole.Mementos.Concrets;

// The Concrete memento contains the infrastructure for storing the Originator's state.
internal class ConcreteMemento : IMemento
{
    private string state;

    private DateTime _date;


    public ConcreteMemento(string state)
    {
        this.state = state;
        _date = DateTime.Now;
    }

    // The Originator uses this method when restoring its state.
    public string GetState()
    {
        return state;
    }

    // The rest of the methods are used by the Caretaker to display metadata.
    public string GetName()
    {
        return $"{_date} / ({state[..9]}...)";
    }

    public DateTime GetDate()
    {
        return _date;
    }
}