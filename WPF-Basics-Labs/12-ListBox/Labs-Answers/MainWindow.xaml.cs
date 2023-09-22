using System.Windows;

namespace ListBoxSamples {
  public partial class MainWindow : Window {
    public MainWindow() {
      InitializeComponent();
    }

    private void SimpleListBox_Click(object sender, RoutedEventArgs e) {
      new SimpleListBox().Show();
    }

    private void SimpleDataTemplate_Click(object sender, RoutedEventArgs e) {
      new SimpleDataTemplate().Show();
    }

    private void TwoColumn_Click(object sender, RoutedEventArgs e) {
      new TwoColumnListBox().Show();
    }

    private void MultiLine_Click(object sender, RoutedEventArgs e) {
      new MultiLineListBox().Show();
    }
  }
}
