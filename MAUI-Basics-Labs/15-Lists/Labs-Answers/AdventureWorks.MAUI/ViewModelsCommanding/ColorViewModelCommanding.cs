using AdventureWorks.DataLayer;
using AdventureWorks.ViewModelLayer;

namespace AdventureWorks.MAUI.ViewModelsCommanding;

public class ColorViewModelCommanding : ColorViewModel
{
  #region Constructors
  public ColorViewModelCommanding()
  {
  }

  public ColorViewModelCommanding(ColorRepository repo) : base(repo)
  {
  }
  #endregion

  #region Init Method
  public override void Init()
  {
    base.Init();
  }
  #endregion
}
