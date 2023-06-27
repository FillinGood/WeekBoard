using System;
using System.Windows.Input;

namespace WeekBoard {
    public class Command : ICommand {
        public event EventHandler? CanExecuteChanged;
        public Action Action { get; }
        public Func<bool>? Predicate { get; }

        public Command(Action action, Func<bool>? predicate = null) {
            Action = action;
            Predicate = predicate;
        }

        public void Update() {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }

        public bool CanExecute(object? parameter) {
            return Predicate?.Invoke() ?? true;
        }

        public void Execute(object? parameter) {
            Action();
        }
    }
    public class Command<T> : ICommand {
        public event EventHandler? CanExecuteChanged;
        public Action<T> Action { get; }
        public Func<T, bool>? Predicate { get; }

        public Command(Action<T> action, Func<T, bool>? predicate = null) {
            Action = action;
            Predicate = predicate;
        }

        public void Update() {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }

        public bool CanExecute(object? parameter) {
            return Predicate?.Invoke((T)parameter) ?? true;
        }

        public void Execute(object? parameter) {
            Action((T)parameter);
        }
    }
}
