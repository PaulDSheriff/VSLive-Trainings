using AdventureWorks.DataLayer;
using AdventureWorks.ViewModelLayer;

namespace AdventureWorks.MAUI.ViewModelsCommanding;

public class ProductViewModelCommanding : ProductViewModel
{
  #region Constructors
  public ProductViewModelCommanding()
  {
  }

  public ProductViewModelCommanding(ProductRepository repo) : base(repo)
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
