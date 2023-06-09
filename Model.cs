using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WeekBoard {
    public abstract class Model : INotifyPropertyChanged {
        public event PropertyChangedEventHandler? PropertyChanged;
        private readonly Dictionary<string, object?> values = new();
        protected void Notify([CallerMemberName] string prop = "") {
            PropertyChanged?.Invoke(this, new(prop));
        }
        protected void Set(object? value, [CallerMemberName] string prop = "") {
            values[prop] = value;
            Notify(prop);
        }
        protected T Get<T>([CallerMemberName] string prop = "") {
            return values.TryGetValue(prop, out object? value) ? (T)value! : default!;
        }
    }
}
