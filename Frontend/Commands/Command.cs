﻿using System.Windows.Input;

namespace Frontend.Commands;

public class Command : BaseCommand
{
    public Command(Action execute, Predicate<object?> canExecute)
    {
        _execute = execute;
        _canExecute = canExecute;
    }

    public Command(Action execute) : this(execute, (p) => true)
    {
    }

    public override event EventHandler? CanExecuteChanged
    {
        add => CommandManager.RequerySuggested += value;
        remove => CommandManager.RequerySuggested -= value;
    }

    public bool CanExecute()
    {
        return _canExecute(null);
    }

    public override bool CanExecute(object? parameter)
    {
        return _canExecute(parameter);
    }

    public void Execute()
    {
        _execute();
    }

    public override void Execute(object? parameter)
    {
        _execute();
    }

    private readonly Predicate<object?> _canExecute;

    private readonly Action _execute;
}
