using AdventureWorks.ViewModelLayer;
using System.Windows;
using System.Windows.Controls;

namespace AdventureWorks.WPF.Views
{
  public partial class ProductListView : UserControl
  {
    public ProductListView()
    {
      InitializeComponent();

      _ViewModel = (ProductViewModel)this.Resources["viewModel"];
    }

    private ProductViewModel _ViewModel { get; set; }

    private void UserControl_Loaded(object sender, RoutedEventArgs e)
    {
      _ViewModel.Get();
      _ViewModel.GetColors();
    }
  }
}
