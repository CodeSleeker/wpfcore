using System;
using System.Windows.Input;

namespace WpfCore
{
    public class RelayParameterCommand : ICommand
    {
        Action<object> Action;
        public event EventHandler CanExecuteChanged = (sender, e) => { };

        public RelayParameterCommand(Action<object> action)
        {
            Action = action;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            Action(parameter);
        }
    }
}
