using AdventureWorks.EntityLayer;

namespace AdventureWorks.MAUI.Views;

public partial class UserDetailView : ContentPage
{
	public UserDetailView()
	{
		InitializeComponent();

    UserObject = (User)this.Resources["viewModel"];
    //UserObject.LoginId = "asdfasdfasfd";
  }

  public User UserObject { get; set; }

  private void SaveButton_Click(object sender, EventArgs e)
  {
    System.Diagnostics.Debugger.Break();
  }

}