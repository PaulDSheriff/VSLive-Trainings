using AdventureWorks.DataLayer;
using AdventureWorks.EntityLayer;
using Common.Library;
using System.Collections.ObjectModel;

namespace AdventureWorks.ViewModelLayer;

public class UserViewModel : ViewModelBase
{
  #region Constructors
  public UserViewModel()
  {
  }

  public UserViewModel(UserRepository repo, PhoneTypeRepository phoneRepo)
  {
    Repository = repo;
    _PhoneTypeRepository = phoneRepo;
  }
  #endregion

  #region Private Variables
  private ObservableCollection<User> _UserList = new();
  private readonly UserRepository? Repository;
  private User? _UserObject = new();
  private readonly PhoneTypeRepository? _PhoneTypeRepository;
  private ObservableCollection<string> _PhoneTypesList = new();
  #endregion

  #region Public Properties
  public ObservableCollection<User> UserList
  {
    get { return _UserList; }
    set
    {
      _UserList = value;
      RaisePropertyChanged(nameof(UserList));
    }
  }

  public User? UserObject
  {
    get { return _UserObject; }
    set
    {
      _UserObject = value;
      RaisePropertyChanged(nameof(UserObject));
    }
  }

  public ObservableCollection<string> PhoneTypesList
  {
    get { return _PhoneTypesList; }
    set
    {
      _PhoneTypesList = value;
      RaisePropertyChanged(nameof(PhoneTypesList));
    }
  }
  #endregion

  #region Get Method
  public ObservableCollection<User> Get()
  {
    if (Repository != null) {
      UserList = new ObservableCollection<User>(Repository.Get());
    }

    return UserList;
  }
  #endregion

  #region Get(id) Method
  /// <summary>
  /// Get a single user object
  /// </summary>
  /// <param name="id">The UserId to locate</param>
  /// <returns>An instance of a User object</returns>
  public User? Get(int id)
  {
    try {
      if (Repository != null) {
        UserObject = Repository.Get(id);
      }
      else {
        // MOCK Data
        UserObject = new User {
          UserId = id,
          LoginId = "SallyJones",
          FirstName = "Sally",
          LastName = "Jones",
          Email = "Sallyj@jones.com",
          Phone = "615.987.3456",
          PhoneType = "Mobile",
          IsEnrolledIn401k = true,
          IsEnrolledInFlexTime = false,
          IsEnrolledInHealthCare = true,
          IsEnrolledInHSA = false,
          IsActive = true,
          BirthDate = Convert.ToDateTime("08-13-1989")
        };
      }
    }
    catch (Exception ex) {
      System.Diagnostics.Debug.WriteLine(ex.ToString());
    }

    return UserObject;
  }
  #endregion

  #region GetPhoneTypes Method
  public ObservableCollection<string> GetPhoneTypes()
  {
    if (_PhoneTypeRepository != null) {
      var list = _PhoneTypeRepository.Get();

      PhoneTypesList = new ObservableCollection<string>(list.Select(row => row.TypeDescription));
    }

    return PhoneTypesList;
  }
  #endregion

  #region Save Method
  public virtual bool Save()
  {
    // TODO: Write code to save data
    System.Diagnostics.Debugger.Break();

    return true;
  }
  #endregion
}
