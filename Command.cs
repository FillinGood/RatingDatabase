using System;
using System.Windows.Input;

namespace RatingDatabase;
public class Command<T> : ICommand {
    public event EventHandler? CanExecuteChanged;

    public Action<T> Action { get; set; }

    public Command(Action<T> action) { Action = action; }

    public bool CanExecute(object? parameter) {
        return true;
    }

    public void Execute(object? parameter) {
        Action((T)parameter!);
    }

    public void Update() {
        CanExecuteChanged?.Invoke(this, EventArgs.Empty);
    }
}