using System;
using System.Globalization;
using System.Windows.Data;

namespace WeekBoard {
	public class DateOnlyConverter : IValueConverter {
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
			if (targetType == typeof(DateTime)) {
				if (value is DateOnly d) return d.ToDateTime();
				throw new NotSupportedException($"Unable to convert {value} to {targetType}");
			} else if (targetType == typeof(DateTime?)) {
				if (value is null) return null!;
				if (value is DateOnly d) return d.ToDateTime();
				throw new NotSupportedException($"Unable to convert {value} to {targetType}");
			} else if (targetType == typeof(DateOnly)) {
				if (value is DateTime dt) return dt.ToDateOnly();
				throw new NotSupportedException($"Unable to convert {value} to {targetType}");
			} else if (targetType == typeof(DateOnly?)) {
				if (value is null) return null!;
				if (value is DateTime dt) return dt.ToDateOnly();
				throw new NotSupportedException($"Unable to convert {value} to {targetType}");
			} else {
				throw new NotSupportedException($"Unable to convert {value} to {targetType}");
			}
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
			return Convert(value, targetType, parameter, culture);
		}
	}
}
