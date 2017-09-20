using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BooksSample.Models
{
    public abstract class BindableBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual bool SetProperty<T>(ref T item, T value, [CallerMemberName] string propertyName = null)
        {
            if (propertyName == null) throw new ArgumentNullException(nameof(OnPropertyChanged));

            if (EqualityComparer<T>.Default.Equals(item, value)) return false;
            item = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (propertyName == null) throw new ArgumentNullException(nameof(OnPropertyChanged));

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
