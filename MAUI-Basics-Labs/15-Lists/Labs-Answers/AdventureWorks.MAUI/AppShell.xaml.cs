namespace AdventureWorks.MAUI
{
  public partial class AppShell : Shell
  {
    public AppShell()
    {
      InitializeComponent();

      // Add routes
      Routing.RegisterRoute(nameof(Views.UserDetailView), typeof(Views.UserDetailView));
      Routing.RegisterRoute(nameof(Views.ProductDetailView), typeof(Views.ProductDetailView));
    }
  }
}