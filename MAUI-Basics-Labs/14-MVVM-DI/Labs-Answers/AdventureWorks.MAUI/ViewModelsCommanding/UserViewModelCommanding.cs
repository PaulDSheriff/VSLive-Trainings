using AdventureWorks.ViewModelLayer;
using System.Windows.Input;

namespace AdventureWorks.MAUI.ViewModelsCommanding;

public class UserViewModelCommanding : UserViewModel
{
  public UserViewModelCommanding()
  {
    SaveCommand = new Command(() => Save(), () => true);
  }

  public ICommand SaveCommand { get; private set; }
}
