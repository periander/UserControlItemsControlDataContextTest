using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace UserControlItemsControlDataContextTest.MVVM
{
    class DelegateCommand : ICommand
    {
        private readonly Action<object> _execute;
        private readonly Predicate<object> _canExecute;

        public DelegateCommand(Action execute, Predicate<object> canExecute = null)
        {
            if (execute == null) throw new ArgumentNullException(nameof(execute));
            _execute = o => execute();
            _canExecute = canExecute ?? DefaultCanExecute;
        }

        public DelegateCommand(Action<object> execute, Predicate<object> canExecute = null)
        {
            if (execute == null) throw new ArgumentNullException(nameof(execute));
            _execute = execute;
            _canExecute = canExecute ?? DefaultCanExecute;
        }

        public void Execute(object parameter)
        {
            _execute(parameter);
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute(parameter);
        }

        protected virtual bool DefaultCanExecute(object paramerer)
        {
            return true;
        }

#pragma warning disable 67
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
#pragma warning restore 67

        public void RaiseCanExecuteChanged()
        {
            //CanExecuteChanged?.Invoke(this, null);
            CommandManager.InvalidateRequerySuggested();
        }
    }
}
