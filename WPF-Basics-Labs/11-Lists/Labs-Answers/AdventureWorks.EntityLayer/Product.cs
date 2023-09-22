using System;
using Common.Library;

namespace AdventureWorks.EntityLayer;

public partial class Product : EntityBase
{
  #region Private Variables
  private int _ProductID;
  private string _Name = string.Empty;
  private string _ProductNumber = string.Empty;
  private string _Color = string.Empty;
  private decimal _StandardCost;
  private decimal _ListPrice;
  private string _Size = string.Empty;
  private decimal? _Weight;
  private int? _ProductCategoryID;
  private int? _ProductModelID;
  private DateTime _SellStartDate;
  private DateTime? _SellEndDate;
  private DateTime? _DiscontinuedDate;
  private DateTime _ModifiedDate;
  #endregion

  #region Public Properties
  public int ProductID
  {
    get { return _ProductID; }
    set {
      _ProductID = value;
      RaisePropertyChanged(nameof(ProductID));
    }
  }

  public string Name
  {
    get { return _Name; }
    set {
      _Name = value;
      RaisePropertyChanged(nameof(Name));
    }
  }

  public string ProductNumber
  {
    get { return _ProductNumber; }
    set {
      _ProductNumber = value;
      RaisePropertyChanged(nameof(ProductNumber));
    }
  }

  public string Color
  {
    get { return _Color; }
    set {
      _Color = value;
      RaisePropertyChanged(nameof(Color));
    }
  }

  public decimal StandardCost
  {
    get { return _StandardCost; }
    set {
      _StandardCost = value;
      RaisePropertyChanged(nameof(StandardCost));
    }
  }

  public decimal ListPrice
  {
    get { return _ListPrice; }
    set {
      _ListPrice = value;
      RaisePropertyChanged(nameof(ListPrice));
    }
  }

  public string Size
  {
    get { return _Size; }
    set {
      _Size = value;
      RaisePropertyChanged(nameof(Size));
    }
  }

  public decimal? Weight
  {
    get { return _Weight; }
    set {
      _Weight = value;
      RaisePropertyChanged(nameof(Weight));
    }
  }

  public int? ProductCategoryID
  {
    get { return _ProductCategoryID; }
    set {
      _ProductCategoryID = value;
      RaisePropertyChanged(nameof(ProductCategoryID));
    }
  }

  public int? ProductModelID
  {
    get { return _ProductModelID; }
    set {
      _ProductModelID = value;
      RaisePropertyChanged(nameof(ProductModelID));
    }
  }

  public DateTime SellStartDate
  {
    get { return _SellStartDate; }
    set {
      _SellStartDate = value;
      RaisePropertyChanged(nameof(SellStartDate));
    }
  }

  public DateTime? SellEndDate
  {
    get { return _SellEndDate; }
    set {
      _SellEndDate = value;
      RaisePropertyChanged(nameof(SellEndDate));
    }
  }

  public DateTime? DiscontinuedDate
  {
    get { return _DiscontinuedDate; }
    set {
      _DiscontinuedDate = value;
      RaisePropertyChanged(nameof(DiscontinuedDate));
    }
  }

  public DateTime ModifiedDate
  {
    get { return _ModifiedDate; }
    set {
      _ModifiedDate = value;
      RaisePropertyChanged(nameof(ModifiedDate));
    }
  }
  #endregion
}