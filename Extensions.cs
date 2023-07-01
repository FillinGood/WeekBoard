using System;

namespace WeekBoard {
	public static class Extensions {
		public static DateTime ToDateTime(this DateOnly d) {
			return new DateTime(d.DayNumber * TimeSpan.TicksPerDay);
		}
		public static DateOnly ToDateOnly(this DateTime dt) {
			return new DateOnly(dt.Year, dt.Month, dt.Day);
		}
	}
}
