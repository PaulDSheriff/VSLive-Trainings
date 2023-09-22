using System.Windows;

namespace SimpleDataBindingSamples {
  public partial class MainWindow : Window {
    public MainWindow() {
      InitializeComponent();
    }

    private void TextBoxToLabel_Click(object sender, RoutedEventArgs e) {
      new TextBoxToLabel().Show();
    }

    private void ComboBoxToLabel_Click(object sender, RoutedEventArgs e) {
      new ComboBoxToLabel().Show();
    }

    private void FontFamily_Click(object sender, RoutedEventArgs e) {
      new FontFamilyBinding().Show();
    }

    private void IsEnabled_Click(object sender, RoutedEventArgs e) {
      new IsEnabledBinding().Show();
    }

    private void Visibility_Click(object sender, RoutedEventArgs e) {
      new VisiblityConverter().Show();
    }

    private void NotVisibility_Click(object sender, RoutedEventArgs e) {
      new NotVisiblityConverter().Show();
    }

    private void RadioButton_Click(object sender, RoutedEventArgs e) {
      new RadioButtonBinding().Show();
    }
  }
}
