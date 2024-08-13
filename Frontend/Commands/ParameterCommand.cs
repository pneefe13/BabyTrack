using System.Windows.Input;

namespace Frontend.Commands;

public class ParameterCommand : BaseCommand
{
    public ParameterCommand(Action<object?> execute, Predicate<object?> canExecute)
    {
        _execute = execute;
        _canExecute = canExecute;
    }

    public ParameterCommand(Action<object?> execute) : this(execute, (p) => true)
    {
    }

    public override event EventHandler? CanExecuteChanged
    {
        add => CommandManager.RequerySuggested += value;
        remove => CommandManager.RequerySuggested -= value;
    }

    public override bool CanExecute(object? parameter)
    {
        return _canExecute(parameter);
    }

    public override void Execute(object? parameter)
    {
        _execute(parameter);
    }

    private readonly Predicate<object?> _canExecute;

    private readonly Action<object?> _execute;
}
