using AdventureWorks.ViewModelLayer;
using System.Windows;
using System.Windows.Controls;

namespace AdventureWorks.WPF.Views;

public partial class UserDetailView : UserControl
{
  public UserDetailView()
  {
    InitializeComponent();

    ViewModel = (UserViewModel)this.Resources["viewModel"];
  }

  public UserViewModel ViewModel { get; set; }


  private void UserControl_Loaded(object sender, RoutedEventArgs e)
  {
    ViewModel.Get(8);
  }
  
  private void SaveButton_Click(object sender, RoutedEventArgs e)
  {
    System.Diagnostics.Debugger.Break();
  }
  }
