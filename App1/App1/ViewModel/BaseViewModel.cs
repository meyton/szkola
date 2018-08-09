using System;
using System.ComponentModel;

namespace App1.ViewModel
{
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged(string name)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(name));
        }

        private bool _isBusy;
        public bool IsBusy { get => _isBusy;
            set
            {
                if (value != _isBusy)
                {
                    _isBusy = value;
                    RaisePropertyChanged(nameof(IsBusy));
                    ((App)App.Current).Navi.IsEnabled = !IsBusy;
                }
            }
        } 
    }
}