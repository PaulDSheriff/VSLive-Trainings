using AdventureWorks.WPF.Views;
using System.Windows;
using System.Windows.Controls;

namespace AdventureWorks.WPF {
  public partial class MainWindow : Window {
    public MainWindow() {
      InitializeComponent();
    }

    private void Window_Loaded(object sender, RoutedEventArgs e) {
      ContentArea.Children.Add(new HomeView());
    }

    private void Menu_Click(object sender, RoutedEventArgs e) {
      MenuItem mnu = ((MenuItem)e.Source);
      string? tag = mnu.Tag == null ? "" : mnu.Tag as string;

      if (!string.IsNullOrEmpty(tag)) {
        ContentArea.Children.Clear();
        switch (tag.ToLower()) {
          case "homeview":
            ContentArea.Children.Add(new HomeView());
            break;
          case "loginview":
            ContentArea.Children.Add(new LoginView());
            break;
          case "userlistview":
            ContentArea.Children.Add(new UserListView());
            break;
          case "productlistview":
            ContentArea.Children.Add(new ProductListView());
            break;
          case "exit":
            this.Close();
            break;
        }
      }
    }
  }
}
