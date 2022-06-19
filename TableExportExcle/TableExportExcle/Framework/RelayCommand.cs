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
            //todo 2、为什么会直接调用这个？
            DoExecute?.Invoke(parameter);
        }

        //todo 1、为什么外部赋值属性后就直接去调用 Execute(object? parameter) 函数中的执行语句
        public Action<object?>? DoExecute { get; set; }
    }
}
