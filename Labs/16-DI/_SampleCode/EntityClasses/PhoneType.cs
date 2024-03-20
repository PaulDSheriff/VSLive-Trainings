using System;
using Common.Library;

namespace AdventureWorks.EntityLayer;

public class PhoneType : EntityBase
{
  #region Private Variables
  private int _PhoneTypeId;
  private string _TypeDescription = string.Empty;
  #endregion

  #region Public Properties
  public int PhoneTypeId
  {
    get { return _PhoneTypeId; }
    set {
      _PhoneTypeId = value;
      RaisePropertyChanged(nameof(PhoneTypeId));
    }
  }

  public string TypeDescription
  {
    get { return _TypeDescription; }
    set {
      _TypeDescription = value;
      RaisePropertyChanged(nameof(TypeDescription));
    }
  }
  #endregion
}