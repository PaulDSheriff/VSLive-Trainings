using AdventureWorks.MAUI.ViewModelsCommanding;

namespace AdventureWorks.MAUI.Views;

[QueryProperty(nameof(UserId), "id")]
public partial class UserDetailView : ContentPage
{
  public UserDetailView(UserViewModelCommanding viewModel)
  {
    InitializeComponent();

    ViewModel = viewModel;
  }

  private readonly UserViewModelCommanding ViewModel;
  public int UserId { get; set; }

  protected override void OnAppearing()
  {
    base.OnAppearing();

    BindingContext = ViewModel;

    ViewModel.GetPhoneTypes();
    ViewModel.Get(UserId);
  }
}