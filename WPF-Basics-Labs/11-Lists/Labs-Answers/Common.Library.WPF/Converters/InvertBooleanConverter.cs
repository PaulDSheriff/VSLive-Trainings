using System;
using System.Globalization;
using System.Windows.Data;

namespace Common.Library.WPF;

/// <summary>
/// Call this converter to change a True value to a False and False to a True
/// </summary>
public class InvertBooleanConverter : IValueConverter {
  public object Convert(object value, Type targetType,
                    object parameter, CultureInfo culture) {
    return !(bool)value;
  }

  public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
    return (bool)value;
  }
}
