using System;
using Common.Library;

namespace AdventureWorks.EntityLayer;

public class Color : EntityBase
{
  #region Private Variables
  private string _ColorName = string.Empty;
  #endregion

  #region Public Properties
  public string ColorName
  {
    get { return _ColorName; }
    set {
      _ColorName = value;
      RaisePropertyChanged(nameof(ColorName));
    }
  }
  #endregion
}