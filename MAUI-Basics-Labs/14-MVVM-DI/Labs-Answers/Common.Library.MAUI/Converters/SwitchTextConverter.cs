using System.Globalization;

namespace Common.Library.MAUI
{
  public class SwitchTextConverter : IValueConverter
  {
    public string TrueText { get; set; } = "Yes";
    public string FalseText { get; set; } = "No";

    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
      if ((bool)value) {
        return TrueText;
      }
      else {
        return FalseText;
      }
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
      throw new NotImplementedException();
    }
  }
}
