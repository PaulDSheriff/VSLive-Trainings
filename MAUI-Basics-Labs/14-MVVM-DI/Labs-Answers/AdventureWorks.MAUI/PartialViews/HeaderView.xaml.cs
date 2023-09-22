namespace AdventureWorks.MAUI.PartialViews;

public partial class HeaderView : ContentView
{
	public HeaderView()
	{
		InitializeComponent();

    this.BindingContext = this;
    ViewTitle = "View Title";
    ViewSubTitle = "View Sub Title";
  }

  public string ViewTitle
  {
    get { return (string)GetValue(ViewTitleProperty); }
    set { SetValue(ViewTitleProperty, value); }
  }

  public static readonly BindableProperty ViewTitleProperty =
  BindableProperty.Create("ViewTitle", typeof(string), typeof(HeaderView), string.Empty);

  public string ViewSubTitle
  {
    get { return (string)GetValue(ViewSubTitleProperty); }
    set { SetValue(ViewSubTitleProperty, value); }
  }

  public static readonly BindableProperty ViewSubTitleProperty =
  BindableProperty.Create("ViewSubTitle", typeof(string), typeof(HeaderView), string.Empty);
}