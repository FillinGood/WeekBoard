using System;
using System.Collections.ObjectModel;

namespace WeekBoard {
    public class BoardDay : Model {
        public DateOnly Date { get => Get<DateOnly>(); private init => Set(value); }
        public ObservableCollection<BoardTask> Tasks { get; } = new();

        public BoardDay(DateOnly date) {
            Date = date;
        }

        public void RefreshTasks() {
            Tasks.Clear();
            foreach(BoardTask task in WeekBoard.Tasks.All) {
                if(task.MatchesDay(Date))
                    Tasks.Add(task);
            }
        }

        public override string ToString() {
            return Date.ToString();
        }
    }
}
