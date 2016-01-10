using System;
using System.Windows.Input;

namespace RestaurantManager.ViewModels
{
    public class DelegateCommand : ICommand
    {

        private readonly Func<object,bool> _canExecuteMethod;
        private readonly Action<object> _executeMethod;

        #region Constructors

        public DelegateCommand(Action<object> executeMethod)
            : this(executeMethod, null)
        {
        }

        public DelegateCommand(Action<object> executeMethod, Func<object,bool> canExecuteMethod)
        {
            _executeMethod = executeMethod;
            _canExecuteMethod = canExecuteMethod;
        }

        #endregion Constructors

        #region ICommand Members

        public event EventHandler CanExecuteChanged;

        bool ICommand.CanExecute(object parameter)
        {
            try
            {
                return CanExecute(parameter);
            }
            catch { return false; }
        }

        void ICommand.Execute(object parameter)
        {
            Execute(parameter);
        }

        #endregion ICommand Members

        #region Public Methods

        public bool CanExecute(object parameter)
        {
            return ((_canExecuteMethod == null) || _canExecuteMethod(parameter));
        }

        public void Execute(object parameter)
        {
            if (_executeMethod != null)
            {
                _executeMethod(parameter);
            }
        }

        public void RaiseCanExecuteChanged()
        {
            OnCanExecuteChanged(EventArgs.Empty);
        }

        #endregion Public Methods

        #region Protected Methods

        protected virtual void OnCanExecuteChanged(EventArgs e)
        {
            var handler = CanExecuteChanged;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        #endregion Protected Methods

    }
}
