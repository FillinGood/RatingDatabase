using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace RatingDatabase;
public abstract class Model : INotifyPropertyChanged {
    public event PropertyChangedEventHandler? PropertyChanged;
    private readonly Dictionary<string, object> _properties = new();
    protected void Set(object value, [CallerMemberName] string prop = "") {
        _properties[prop] = value;
        Notify(prop);
    }
    protected T Get<T>([CallerMemberName] string prop = "") {
        return _properties.TryGetValue(prop, out object? value) ? (T)value! : default!;
    }
    protected void Notify([CallerMemberName] string prop = "") {
        PropertyChanged?.Invoke(this, new(prop));
    }
}
