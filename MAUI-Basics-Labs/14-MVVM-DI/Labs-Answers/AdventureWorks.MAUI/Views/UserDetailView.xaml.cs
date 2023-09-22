using AdventureWorks.MAUI.ViewModelsCommanding;

namespace AdventureWorks.MAUI.Views;

public partial class UserDetailView : ContentPage
{
  public UserDetailView(UserViewModelCommanding viewModel)
  {
    InitializeComponent();

    ViewModel = viewModel;
  }

  private readonly UserViewModelCommanding ViewModel;

  protected override void OnAppearing()
  {
    base.OnAppearing();

    BindingContext = ViewModel;

    ViewModel.Get(8);
  }
}