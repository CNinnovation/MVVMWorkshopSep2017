using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace TheBestMVVMFrameworkInTown
{
    public class DelegateCommand : ICommand
    {
        private Action _action;
        private Func<bool> _canExecute;
        public DelegateCommand(Action action)
            : this(action, null)
        {

        }

        public DelegateCommand(Action action, Func<bool> canExecute)
        {
            _action = action;
            _canExecute = canExecute;
        }

        public event EventHandler CanExecuteChanged;

        //public bool CanExecute(object parameter)
        //{
        //    if (_canExecute == null) return true;
        //    return _canExecute();
        //}

        public bool CanExecute(object parameter) => _canExecute?.Invoke() ?? true;

        public void Execute(object parameter)
        {
            _action();
        }
    }
}
