using System;

namespace WeekBoard {
    public class BoardDay : Model {
        public DateOnly Date { get => Get<DateOnly>(); private init => Set(value); }

        public BoardDay(DateOnly date) {
            Date = date;
        }

        public override string ToString() {
            return Date.ToString();
        }
    }
}
