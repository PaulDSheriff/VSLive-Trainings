using AdventureWorks.EntityLayer;
using AdventureWorks.MAUI.ViewModelsCommanding;

namespace AdventureWorks.MAUI.Views;

public partial class ProductListView : ContentPage
{
  public ProductListView(ProductViewModelCommanding viewModel)
  {
    InitializeComponent();

    ViewModel = viewModel;
  }

  private readonly ProductViewModelCommanding ViewModel;

  protected override void OnAppearing()
  {
    base.OnAppearing();

    BindingContext = ViewModel;

    ViewModel.Get();
  }

  private async void productList_SelectionChanged(object sender, SelectionChangedEventArgs e)
  {
    CollectionView lst = sender as CollectionView;
    int id = 0;

    if (lst.SelectedItem != null) {
      id = ((Product)lst.SelectedItem).ProductID;
      await Shell.Current.GoToAsync($"{nameof(Views.ProductDetailView)}?id={id}");
    }
  }
}