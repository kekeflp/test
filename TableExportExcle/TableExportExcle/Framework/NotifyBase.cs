using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TableExportExcle.Framework
{
    internal class NotifyBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        public void SetProperty<T>(ref T field, T value, [CallerMemberName] string propertyName = "")
        {
            field = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
