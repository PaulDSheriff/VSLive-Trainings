using AdventureWorks.MAUI.ViewModelsCommanding;

namespace AdventureWorks.MAUI.Views;

public partial class ColorListView : ContentPage
{
  public ColorListView(ColorViewModelCommanding viewModel)
  {
    InitializeComponent();

    ViewModel = viewModel;
  }

  private readonly ColorViewModelCommanding ViewModel;

  protected override void OnAppearing()
  {
    base.OnAppearing();

    BindingContext = ViewModel;

    ViewModel.Get();
    colorIndicators.Count = ViewModel.ColorList.Count;
  }

  private void colorList_PositionChanged(object sender, PositionChangedEventArgs e)
  {
    colorIndicators.Position = e.CurrentPosition;
  }

}