using System;

namespace WeekBoard {
    public class Controller : Model {
        public BoardDay[] Days { get => Get<BoardDay[]>(); private set => Set(value); }

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

        public Controller() {
            GenerateDays(DateOnly.FromDateTime(DateTime.Today));
        }
    }
}
