using System;
using System.Windows.Input;

namespace TableExportExcle.Framework
{
    internal class RelayCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter) => true;

        public void Execute(object? parameter)
        {
            DoExecute?.Invoke(parameter);
        }

        public Action<object?>? DoExecute;
    }
}
