using AdventureWorks.DataLayer;
using AdventureWorks.EntityLayer;
using Common.Library;
using System.Collections.ObjectModel;

namespace AdventureWorks.ViewModelLayer;

public class UserViewModel : ViewModelBase
{
  #region Private Variables
  private UserRepository _UserRepository = new();
  private PhoneTypeRepository _PhoneTypeRepository = new();
  private ObservableCollection<PhoneType> _PhoneTypesList = new();
  private ObservableCollection<User> _UserList = new();
  private User _UserObject = new();
  #endregion

  #region Public Properties
  public User UserObject
  {
    get { return _UserObject; }
    set
    {
      _UserObject = value;
      RaisePropertyChanged(nameof(UserObject));
    }
  }

  public ObservableCollection<User> UserList
  {
    get { return _UserList; }
    set
    {
      _UserList = value;
      RaisePropertyChanged(nameof(UserList));
    }
  }

  public ObservableCollection<PhoneType> PhoneTypesList
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
    UserList = new ObservableCollection<User>(_UserRepository.Get());

    return UserList;
  }
  #endregion

  #region Get(id) Method
  /// <summary>
  /// Get a single user object
  /// </summary>
  /// <param name="id">The UserId to locate</param>
  /// <returns>An instance of a User object</returns>
  public User Get(int id)
  {
    try {
      // Get a User from a data store
      var user = _UserRepository.Get(id);
      // Check to make sure you get something back
      // Otherwise, just return some mock data
      if (user == null) {
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
      else {
        UserObject = user;
      }
    }
    catch (Exception ex) {
      System.Diagnostics.Debug.WriteLine(ex.ToString());
    }

    return _UserObject;
  }
  #endregion

  #region GetPhoneTypes Method
  public ObservableCollection<PhoneType> GetPhoneTypes()
  {
    PhoneTypesList = new ObservableCollection<PhoneType>(_PhoneTypeRepository.Get());

    return PhoneTypesList;
  }
  #endregion
}
