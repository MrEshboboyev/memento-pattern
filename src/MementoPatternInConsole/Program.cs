﻿// Client code
using MementoPatternInConsole;

Originator originator = new Originator("Super-duper-super-puper-super.");
Caretaker caretaker = new Caretaker(originator);

caretaker.Backup();
originator.DoSomething();

caretaker.Backup();
originator.DoSomething();

caretaker.Backup();
originator.DoSomething();

Console.WriteLine();
caretaker.ShowHistory();

Console.WriteLine("\nClient: Now, let's rollback!\n");
caretaker.Undo();

Console.WriteLine("\nClient: Once more!\n");
caretaker.Undo();

Console.WriteLine();
