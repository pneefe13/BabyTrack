using System.Windows.Input;

namespace Frontend.Commands;

public abstract class BaseCommand : ICommand
{
    public abstract event EventHandler? CanExecuteChanged;

    public abstract bool CanExecute(object? parameter);

    public abstract void Execute(object? parameter);
}
