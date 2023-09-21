namespace XamlBindingMAUI.Views;

public partial class SliderToLabelView : ContentPage
{
  public SliderToLabelView()
  {
    InitializeComponent();
  }

  private void slider_ValueChanged(object sender, ValueChangedEventArgs e)
  {
    // Only increment by whole numbers
    if (slider != null) {
      slider.Value = Convert.ToInt32(e.NewValue);
    }
  }
}