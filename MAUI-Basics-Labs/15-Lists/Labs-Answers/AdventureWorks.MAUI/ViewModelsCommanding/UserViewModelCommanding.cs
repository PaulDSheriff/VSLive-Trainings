using AdventureWorks.DataLayer;
using AdventureWorks.ViewModelLayer;
using System.Windows.Input;

namespace AdventureWorks.MAUI.ViewModelsCommanding;

public class UserViewModelCommanding : UserViewModel
{
  #region Constructors
  public UserViewModelCommanding()
  {
  }

  public UserViewModelCommanding(UserRepository repo, PhoneTypeRepository phoneRepo) : base(repo, phoneRepo)
  {
  }
  #endregion

  #region Init Method
  public override void Init()
  {
    base.Init();

    SaveCommand = new Command(async () => await Save(), () => true);
  }
  #endregion

  public ICommand SaveCommand { get; private set; }

  public new async Task<bool> Save()
  {
    var ret = base.Save();

    if (true) {
      await Shell.Current.GoToAsync($"///{nameof(Views.UserListView)}");
    }

    return ret;
  }
}
