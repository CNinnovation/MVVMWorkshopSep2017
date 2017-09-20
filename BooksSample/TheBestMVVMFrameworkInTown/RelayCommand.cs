using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace TheBestMVVMFrameworkInTown
{
    public class RelayCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private Action _execute;
        private Func<bool> _canExecute;
        public RelayCommand(Action execute, Func<bool> canExecute)
        {
            _execute = execute;
      
            _canExecute = canExecute;
        }

        public RelayCommand(Action execute)
            : this(execute, null)
        {
        }

        public bool CanExecute(object parameter) => _canExecute?.Invoke() ?? true;
        //public bool CanExecute(object parameter)
        //{
        //    if (_canExecute == null)
        //    {
        //        return true;
        //    }
        //    return _canExecute();
        //}


        public void Execute(object parameter) => _execute();

    }
}
