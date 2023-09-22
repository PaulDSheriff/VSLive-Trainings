using AdventureWorks.DataLayer;
using AdventureWorks.EntityLayer;
using Common.Library;
using System.Collections.ObjectModel;

namespace AdventureWorks.ViewModelLayer;

public class ColorViewModel : ViewModelBase
{
  #region Constructors
  public ColorViewModel()
  {
  }

  public ColorViewModel(ColorRepository repo)
  {
    Repository = repo;
  }
  #endregion

  #region Private Variables
  private ColorRepository? Repository;
  private ObservableCollection<Color> _ColorList = new();
  #endregion

  #region Public Properties
  public ObservableCollection<Color> ColorList
  {
    get { return _ColorList; }
    set
    {
      _ColorList = value;
      RaisePropertyChanged(nameof(ColorList));
    }
  }
  #endregion

  #region Get Method
  public ObservableCollection<Color> Get()
  {
    if (Repository != null) {
      ColorList = new ObservableCollection<Color>(Repository.Get());
    }

    return ColorList;
  }
  #endregion
}
