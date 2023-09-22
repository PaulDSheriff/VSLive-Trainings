using AdventureWorks.EntityLayer;
using Common.Library;

namespace AdventureWorks.ViewModelLayer;

public class UserViewModel : ViewModelBase
{
  #region Private Variables
  private User? _UserObject = new();
  #endregion

  #region Public Properties
  public User? UserObject
  {
    get { return _UserObject; }
    set
    {
      _UserObject = value;
      RaisePropertyChanged(nameof(UserObject));
    }
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
      // TODO: Get a User from a data store

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
    catch (Exception ex) {
      System.Diagnostics.Debug.WriteLine(ex.ToString());
    }

    return UserObject;
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
