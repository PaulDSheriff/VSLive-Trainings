using AdventureWorks.EntityLayer;
using AdventureWorks.MAUI.ViewModelsCommanding;

namespace AdventureWorks.MAUI.Views;

public partial class UserListView : ContentPage
{
  public UserListView(UserViewModelCommanding viewModel)
  {
    InitializeComponent();

    ViewModel = viewModel;
  }

  private readonly UserViewModelCommanding ViewModel;

  protected override void OnAppearing()
  {
    base.OnAppearing();

    BindingContext = ViewModel;
        
    ViewModel.Get();
  }

  private async void userList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
  {
    ListView lst = sender as ListView;
    int id = 0;

    if (lst.SelectedItem != null) {
      id = ((User)lst.SelectedItem).UserId;
      await Shell.Current.GoToAsync($"{nameof(Views.UserDetailView)}?id={id}");
    }
  }

}