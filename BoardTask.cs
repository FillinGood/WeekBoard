using System;

namespace WeekBoard {
    public class BoardTask : Model {
        public DateOnly StartDate { get => Get<DateOnly>(); set => Set(value); }
        public DateOnly? EndDate { get => Get<DateOnly?>(); set => Set(value); }
        public string Name { get => Get<string>(); set => Set(value); }
        public string Description { get => Get<string>(); set => Set(value); }
        public TimeSpan? Interval { get => Get<TimeSpan?>(); set => Set(value); }
        public bool IsSelected { get => Get<bool>(); set => Set(value); }

        public BoardTask(DateOnly start) {
            StartDate= start;
            Name = "";
            Description = "";
        }

        public bool MatchesDay(DateOnly date) {
            if (date < StartDate) return false;
            if (EndDate.HasValue) {
                if (EndDate < date) return false;
                
                for (DateOnly day = StartDate; day < EndDate; day = day.AddDays((int)Interval!.Value.TotalDays)) {
                    if (day == date) return true;
                }
                return false;
            }
            return date == StartDate;
        }
    }
}
