using AdventureWorks.EntityLayer;
using AdventureWorks.ViewModelLayer;
using System.Windows;
using System.Windows.Controls;

namespace AdventureWorks.WPF.Views
{
  public partial class ProductDetailView : UserControl
  {
    public ProductDetailView()
    {
      InitializeComponent();
    }

    public ProductViewModel ViewModel
    {
      get { return (ProductViewModel)GetValue(ViewModelProperty); }
      set { SetValue(ViewModelProperty, value); }
    }

    // Using a DependencyProperty as the backing store for ViewModel.  This enables animation, styling, binding, etc...
    public static readonly DependencyProperty ViewModelProperty =
        DependencyProperty.Register("ViewModel", typeof(ProductViewModel), typeof(ProductDetailView), new PropertyMetadata(null));

    private void SaveButton_Click(object sender, RoutedEventArgs e)
    {
      ViewModel.ProductObject = (Product)this.DataContext;
      System.Diagnostics.Debugger.Break();
    }
  }
}
