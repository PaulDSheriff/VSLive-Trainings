using System.Windows;

namespace XamlBasicsLabWPF {
  public partial class MainWindow : Window {
    public MainWindow() {
      InitializeComponent();
    }

    private void SaveButton_Click(object sender, RoutedEventArgs e) {
      MessageBox.Show("User Saved");
    }
  }
}
