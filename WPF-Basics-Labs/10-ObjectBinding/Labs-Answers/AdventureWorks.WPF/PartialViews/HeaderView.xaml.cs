using System.Windows;
using System.Windows.Controls;

namespace AdventureWorks.WPF.PartialViews {
  public partial class HeaderView : UserControl {
    public HeaderView() {
      InitializeComponent();
    }

    public string ViewTitle
    {
      get { return (string)GetValue(ViewTitleProperty); }
      set { SetValue(ViewTitleProperty, value); }
    }

    // Using a DependencyProperty as the backing store for ViewTitle.  This enables animation, styling, binding, etc...
    public static readonly DependencyProperty ViewTitleProperty =
        DependencyProperty.Register("ViewTitle", typeof(string), typeof(HeaderView), new PropertyMetadata("View Title"));

    public string ViewSubTitle
    {
      get { return (string)GetValue(ViewSubTitleProperty); }
      set { SetValue(ViewSubTitleProperty, value); }
    }

    // Using a DependencyProperty as the backing store for ViewSubTitle.  This enables animation, styling, binding, etc...
    public static readonly DependencyProperty ViewSubTitleProperty =
        DependencyProperty.Register("ViewSubTitle", typeof(string), typeof(HeaderView), new PropertyMetadata("View Sub Title"));
  }
}
