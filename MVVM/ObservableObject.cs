using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserControlItemsControlDataContextTest.MVVM
{
    class ObservableObject : INotifyPropertyChanged, INotifyPropertyChanging
    {
        public event PropertyChangingEventHandler PropertyChanging;
        protected virtual void OnPropertyChanging(string propertyName)
        {
            PropertyChanging?.Invoke(this, new PropertyChangingEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected void SetProperty<T>(string propertyName,
            ref T backingStore,
            T value,
            Action onChanged = null,
            Action<T> onChanging = null)
        {
            if (string.IsNullOrWhiteSpace(propertyName)) throw new ArgumentNullException(nameof(propertyName));
            if (EqualityComparer<T>.Default.Equals(backingStore, value)) return;
            onChanging?.Invoke(value);
            OnPropertyChanging(propertyName);
            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
        }

        protected static bool GetIsInDesignMode()
        {
            return DesignerProperties.GetIsInDesignMode(new System.Windows.DependencyObject());
        }
    }
}
