using System.Windows;

namespace SimpleDataBindingSamples {
  public partial class RadioButtonBinding : Window {
    public RadioButtonBinding() {
      InitializeComponent();

      CanSellProduct = false;
      this.DataContext = this;
    }

    public bool CanSellProduct { get; set; }
  }
}
