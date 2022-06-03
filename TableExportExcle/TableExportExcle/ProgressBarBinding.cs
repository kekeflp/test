using System.ComponentModel;

namespace TableExportExcle
{
    internal class ProgressBarBinding : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        public void OnProperyChange(PropertyChangedEventArgs e)
        {
            PropertyChanged?.Invoke(this, e);
        }

        private float _barBindingValue;

        public float BarBindingValue
        {
            get { return _barBindingValue; }
            set
            {
                _barBindingValue = value;
                OnProperyChange(new PropertyChangedEventArgs(nameof(BarBindingValue)));
            }
        }

    }
}
