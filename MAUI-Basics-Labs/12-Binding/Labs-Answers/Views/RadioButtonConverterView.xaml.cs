namespace XamlBindingMAUI.Views;

public partial class RadioButtonConverterView : ContentPage
{
	public RadioButtonConverterView()
	{
		InitializeComponent();

    this.BindingContext = this;
    IsActive = false;
  }

  public bool IsActive { get; set; }
}