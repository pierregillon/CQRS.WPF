using System.Collections.Generic;
using System.ComponentModel;

namespace CQRS.WPF.Client.Business.ViewModels.Base
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        private readonly Dictionary<string, object> _propertyNameToValue = new Dictionary<string, object>();

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }

        protected T GetNotifiableProperty<T>(string propertyName)
        {
            if (_propertyNameToValue.ContainsKey(propertyName)) {
                return (T) _propertyNameToValue[propertyName];
            }
            return default(T);
        }
        protected void SetNotifiableProperty<T>(string propertyName, T value)
        {
            if (_propertyNameToValue.ContainsKey(propertyName) == false) {
                _propertyNameToValue.Add(propertyName, default(T));
            }
            _propertyNameToValue[propertyName] = value;
            OnPropertyChanged(propertyName);
        }
    }
}