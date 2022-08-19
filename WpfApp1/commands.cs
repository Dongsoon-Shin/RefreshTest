using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfApp1
{
    public class commands : ICommand
    {
        public event EventHandler? CanExecuteChanged;
        Action<object> _executeCommand { get; set; }
        Func<object, bool> _canExecuteCommand { get; set; }

        public commands(Action<object> executeCommand, Func<object, bool> canExecuteCommand)
        {
            _executeCommand = executeCommand;
            _canExecuteCommand = canExecuteCommand;
        }
        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            _executeCommand(parameter);
        }
    }
}
