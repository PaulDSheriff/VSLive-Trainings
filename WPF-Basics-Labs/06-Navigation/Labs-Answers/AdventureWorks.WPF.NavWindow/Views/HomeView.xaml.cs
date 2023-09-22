using System.Windows;
using System.Windows.Controls;

namespace AdventureWorks.WPF.NavWindow.Views {
  public partial class HomeView : Page {
    public HomeView() {
      InitializeComponent();
    }

    private void Button_Click(object sender, RoutedEventArgs e) {
      Button btn = ((Button)e.Source);
      string? tag = btn.Tag == null ? "" : btn.Tag as string;

      if (!string.IsNullOrEmpty(tag)) {
        switch (tag.ToLower()) {
          case "homeview":
            this.NavigationService.Navigate(new HomeView());
            break;
          case "loginview":
            this.NavigationService.Navigate(new LoginView());
            break;
        }
      }
    }
  }
}
