using System.Windows.Input;

namespace Frontend.Commands
{
    public class Command : ICommand
    {
        public Predicate<object?> CanExecuteFunc { get; set; } = (p) => false;

        public Action<object?> ExecuteFunc { get; set; } = (a) => {};

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return CanExecuteFunc(parameter);
        }

        public void Execute(object? parameter)
        {
            ExecuteFunc(parameter);
        }
    }
}
