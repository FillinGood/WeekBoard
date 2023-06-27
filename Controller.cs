using System;
using System.Diagnostics;

namespace WeekBoard {
    public class Controller : Model {
        public BoardDay[] Days { get => Get<BoardDay[]>(); private set => Set(value); }
        public BoardTask? SelectedTask { get => Get<BoardTask>(); private set => Set(value); }
        public Command<BoardTask> TaskClickCommand { get; }

        private void OnTaskClick(BoardTask task) {
            Debug.WriteLine("OnTaskClick " + task);
            if(SelectedTask is not null)
                SelectedTask.IsSelected = false;
            SelectedTask = task;
            task.IsSelected = true;
        }
        private void GenerateDays(DateOnly date) {
            // day of week index start from monday
            int offset = date.DayOfWeek == DayOfWeek.Sunday ? 6 : (int)date.DayOfWeek - 1;
            // move date to previous monday
            date = date.AddDays(-offset);

            BoardDay[] days = new BoardDay[14];
            for(int i = 0; i < 14; ++i) {
                days[i] = new(date);
                date = date.AddDays(1);
            }
            Days = days;
        }

        private void RefreshTasks() {
            foreach(BoardDay day in Days)
                day.RefreshTasks(); 
        }

        public Controller() {
            TaskClickCommand = new(OnTaskClick);
            GenerateDays(DateOnly.FromDateTime(DateTime.Today));

            BoardTask[] tasks = new BoardTask[] {
                new (DateOnly.ParseExact("27.06.2023", "dd.MM.yyyy")) {
                    EndDate = DateOnly.ParseExact("27.07.2023", "dd.MM.yyyy"),
                    Interval = TimeSpan.FromDays(7)
                }, 
                new (DateOnly.ParseExact("29.06.2023", "dd.MM.yyyy")) { Name = "Zavtra" }, 
                new (DateOnly.ParseExact("28.06.2023", "dd.MM.yyyy")) { Name = "POTOM", Description = "NEPONYATNO" } 
            };
            TaskSerializer.Save(tasks);
            Tasks.Set(tasks);
            RefreshTasks();
        }
    }
}
