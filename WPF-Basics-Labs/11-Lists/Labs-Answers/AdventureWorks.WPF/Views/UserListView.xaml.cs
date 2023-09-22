using AdventureWorks.ViewModelLayer;
using System.Windows;
using System.Windows.Controls;

namespace AdventureWorks.WPF.Views
{
  public partial class UserListView : UserControl
  {
    public UserListView()
    {
      InitializeComponent();

      _ViewModel = (UserViewModel)this.Resources["viewModel"];
    }

    private UserViewModel _ViewModel { get; set; }

    private void UserControl_Loaded(object sender, RoutedEventArgs e)
    {
      _ViewModel.Get();
      _ViewModel.GetPhoneTypes();
    }
  }
}
