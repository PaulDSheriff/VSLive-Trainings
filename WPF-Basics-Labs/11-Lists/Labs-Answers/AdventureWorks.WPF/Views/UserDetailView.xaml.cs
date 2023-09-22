using AdventureWorks.ViewModelLayer;
using System.Windows.Controls;
using System.Windows;
using AdventureWorks.EntityLayer;

namespace AdventureWorks.WPF.Views;

public partial class UserDetailView : UserControl
{
  public UserDetailView()
  {
    InitializeComponent();
  }

  public UserViewModel ViewModel
  {
    get { return (UserViewModel)GetValue(ViewModelProperty); }
    set { SetValue(ViewModelProperty, value); }
  }

  // Using a DependencyProperty as the backing store for ViewModel.  This enables animation, styling, binding, etc...
  public static readonly DependencyProperty ViewModelProperty =
      DependencyProperty.Register("ViewModel", typeof(UserViewModel), typeof(UserDetailView), new PropertyMetadata(null));

  private void SaveButton_Click(object sender, RoutedEventArgs e)
  {
    ViewModel.UserObject = (User)this.DataContext;
    System.Diagnostics.Debugger.Break();
  }
}
