using AdventureWorks.MAUI.ViewModelsCommanding;

namespace AdventureWorks.MAUI.Views;

[QueryProperty(nameof(ProductId), "id")]
public partial class ProductDetailView : ContentPage
{
	public ProductDetailView(ProductViewModelCommanding viewModel)
	{
		InitializeComponent();

    ViewModel = viewModel;
  }

  private readonly ProductViewModelCommanding ViewModel;
  public int ProductId { get; set; }

  protected override void OnAppearing()
  {
    base.OnAppearing();

    BindingContext = ViewModel;

    ViewModel.Get(ProductId);
  }
}