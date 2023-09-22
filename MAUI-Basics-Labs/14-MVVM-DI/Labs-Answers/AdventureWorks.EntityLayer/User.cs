using Common.Library;

namespace AdventureWorks.EntityLayer;

public class User : EntityBase
{
  #region Constructor
  public User()
  {
    _LoginId = string.Empty;
    _FirstName = string.Empty;
    _LastName = string.Empty;
    _Email = string.Empty;
    _Password = string.Empty;
    _Phone = string.Empty;
    _PhoneType = string.Empty;
  }
  #endregion

  #region Private Variables
  private int _UserId { get; set; }
  private string _LoginId;
  private string _FirstName { get; set; }
  private string _LastName { get; set; }
  private string _Email { get; set; }
  private string _Password { get; set; }
  private string _Phone { get; set; }
  private string _PhoneType { get; set; }
  private bool _IsEnrolledIn401k { get; set; }
  private bool _IsEnrolledInHealthCare { get; set; }
  private bool _IsEnrolledInHSA { get; set; }
  private bool _IsEnrolledInFlexTime { get; set; }
  private bool _IsActive { get; set; }
  private DateTime _BirthDate { get; set; }
  #endregion

  #region Public Properties
  public int UserId
  {
    get { return _UserId; }
    set
    {
      _UserId = value;
      RaisePropertyChanged(nameof(UserId));
    }
  }

  public string LoginId
  {
    get { return _LoginId; }
    set
    {
      _LoginId = value;
      RaisePropertyChanged(nameof(LoginId));
    }
  }

  public string FirstName
  {
    get { return _FirstName; }
    set
    {
      _FirstName = value;
      RaisePropertyChanged(nameof(FirstName));
    }
  }

  public string LastName
  {
    get { return _LastName; }
    set
    {
      _LastName = value;
      RaisePropertyChanged(nameof(LastName));
    }
  }

  public string Email
  {
    get { return _Email; }
    set
    {
      _Email = value;
      RaisePropertyChanged(nameof(Email));
    }
  }

  public string Password
  {
    get { return _Password; }
    set
    {
      _Password = value;
      RaisePropertyChanged(nameof(Password));
    }
  }

  public string Phone
  {
    get { return _Phone; }
    set
    {
      _Phone = value;
      RaisePropertyChanged(nameof(Phone));
    }
  }

  public string PhoneType
  {
    get { return _PhoneType; }
    set
    {
      _PhoneType = value;
      RaisePropertyChanged(nameof(PhoneType));
    }
  }

  public bool IsEnrolledIn401k
  {
    get { return _IsEnrolledIn401k; }
    set
    {
      _IsEnrolledIn401k = value;
      RaisePropertyChanged(nameof(IsEnrolledIn401k));
    }
  }

  public bool IsEnrolledInHealthCare
  {
    get { return _IsEnrolledInHealthCare; }
    set
    {
      _IsEnrolledInHealthCare = value;
      RaisePropertyChanged(nameof(IsEnrolledInHealthCare));
    }
  }

  public bool IsEnrolledInHSA
  {
    get { return _IsEnrolledInHSA; }
    set
    {
      _IsEnrolledInHSA = value;
      RaisePropertyChanged(nameof(IsEnrolledInHSA));
    }
  }

  public bool IsEnrolledInFlexTime
  {
    get { return _IsEnrolledInFlexTime; }
    set
    {
      _IsEnrolledInFlexTime = value;
      RaisePropertyChanged(nameof(IsEnrolledInFlexTime));
    }
  }

  public bool IsActive
  {
    get { return _IsActive; }
    set
    {
      _IsActive = value;
      RaisePropertyChanged(nameof(IsActive));
    }
  }

  public DateTime BirthDate
  {
    get { return _BirthDate; }
    set
    {
      _BirthDate = value;
      RaisePropertyChanged(nameof(BirthDate));
    }
  }
  #endregion
}
