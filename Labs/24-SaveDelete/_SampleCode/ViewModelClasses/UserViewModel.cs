using AdventureWorks.EntityLayer;
using Common.Library;
using System.Collections.ObjectModel;

namespace AdventureWorks.ViewModelLayer;

public class UserViewModel : ViewModelBase
{
  #region Constructors
  public UserViewModel() : base()
  {
  }

  public UserViewModel(IRepository<User> repo) : base()
  {
    Repository = repo;
  }

  public UserViewModel(IRepository<User> repo, IRepository<PhoneType> phoneRepo) : base()
  {
    Repository = repo;
    _PhoneTypeRepository = phoneRepo;
  }
  #endregion

  #region Private Variables
  private ObservableCollection<User> _Users = new();
  private readonly IRepository<User>? Repository;
  private User? _CurrentEntity = new();
  private readonly IRepository<PhoneType>? _PhoneTypeRepository;
  private ObservableCollection<string> _PhoneTypesList = new();
  #endregion

  #region Public Properties
  public ObservableCollection<User> Users
  {
    get { return _Users; }
    set
    {
      _Users = value;
      RaisePropertyChanged(nameof(Users));
    }
  }

  public User? CurrentEntity
  {
    get { return _CurrentEntity; }
    set
    {
      _CurrentEntity = value;
      RaisePropertyChanged(nameof(CurrentEntity));
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

  #region GetAsync Method
  public async Task<ObservableCollection<User>> GetAsync()
  {
    try {
      BeginProcessing();
      if (Repository == null) {
        LastErrorMessage = REPO_NOT_SET;
      }
      else {
        InfoMessage = "Please wait while loading users...";
        //await Task.Run(() => Thread.Sleep(3000));
        Users = new ObservableCollection<User>(await Repository.GetAsync());
        RowsAffected = Users.Count;
        InfoMessage = $"Found {RowsAffected} Users";
      }
    }
    catch (Exception ex) {
      PublishException(ex);
    }
    EndProcessing();

    return Users;
  }
  #endregion

  #region GetAsync(id) Method
  /// <summary>
  /// Get a single user object
  /// </summary>
  /// <param name="id">The UserId to locate</param>
  /// <returns>An instance of a User object</returns>
  public async Task<User?> GetAsync(int id)
  {
    try {
      BeginProcessing();
      // Get a User from a data store
      if (Repository != null) {
        CurrentEntity = await Repository.GetAsync(id);
      }
      else {
        LastErrorMessage = REPO_NOT_SET;

        // MOCK Data
        CurrentEntity = await Task.FromResult(new User {
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
          BirthDate = Convert.ToDateTime("08-13-1989"),
          StartTime = new TimeSpan(7, 30, 0)
        });
      }

      InfoMessage = "Found the User";
      RowsAffected = 1;
    }
    catch (Exception ex) {
      PublishException(ex);
    }
    EndProcessing();

    return CurrentEntity;
  }
  #endregion

  #region SaveAsync Method
  public async virtual Task<User?> SaveAsync()
  {
    User? ret;

    if (IsAdding) {
      ret = await InsertAsync();
    }
    else {
      ret = await UpdateAsync();
    }

    return ret;
  }
  #endregion

  #region InsertAsync Method
  public async Task<User?> InsertAsync()
  {
    return await InsertAsync(CurrentEntity);
  }

  public async Task<User?> InsertAsync(User? entity)
  {
    User? ret = null;

    // Validate Properties
    if (Validate<User>(entity ?? new())) {
      // Ensure Repository Object is Set
      if (Repository == null) {
        LastErrorMessage = REPO_NOT_SET;
      }
      else {
        BeginProcessing();

        try {
          // Insert the new User into data store
          CurrentEntity = await Repository.InsertAsync(entity);
          if (CurrentEntity != null) {
            IsAdding = false;
            RowsAffected = 1;

            // Add new entity to the collection
            Users.Add(CurrentEntity);

            ret = CurrentEntity;
          }
          else {
            RowsAffected = 0;

            // Don't allow a null CurrentEntity
            CurrentEntity = new();
          }
        }
        catch (Exception ex) {
          // Publish the exception here
          PublishException(ex);
        }
      }
    }
    EndProcessing();

    return ret;
  }
  #endregion

  #region UpdateAsync Method
  public async Task<User?> UpdateAsync()
  {
    return await UpdateAsync(CurrentEntity?.UserId ?? 0, CurrentEntity);
  }

  public async Task<User?> UpdateAsync(int id, User? entity)
  {
    User? ret = null;

    // Validate Properties
    if (Validate<User>(entity ?? new())) {
      // Ensure Repository Object is Set
      if (Repository == null) {
        LastErrorMessage = REPO_NOT_SET;
      }
      else {
        BeginProcessing();

        try {
          // Attempt to locate the data to update
          User? current = await Repository.GetAsync(id);

          if (current != null) {
            // Update any common fields

            // Update 'current' with values passed in
            current = SetValues(current, entity ?? new());

            // Update the existing User in the data store
            CurrentEntity = await Repository.UpdateAsync(current);
            if (CurrentEntity != null) {
              RowsAffected = 1;
            }
            else {
              RowsAffected = 0;

              // Don't allow a null CurrentEntity
              CurrentEntity = new();

              ret = CurrentEntity;
            }
          }
        }
        catch (Exception ex) {
          // Publish the exception here
          PublishException(ex);
        }
      }
    }
    EndProcessing();

    return ret;
  }
  #endregion

  #region DeleteAsync Method
  public async Task<User?> DeleteAsync(int id)
  {
    User? ret = new();

    // Ensure Repository Object is Set
    if (Repository == null) {
      LastErrorMessage = REPO_NOT_SET;
    }
    else {
      BeginProcessing();

      try {
        // Attempt to locate the data to delete
        User? entity = await Repository.GetAsync(id);
        if (entity != null) {
          var tmp = await Repository.DeleteAsync(entity);
          if (tmp != null) {
            RowsAffected = 1;

            // Remove entity from collection
            if (Users.Count > 0) {
              Users.Remove(entity);
            }
          }
        }
      }
      catch (Exception ex) {
        // Publish the exception here
        PublishException(ex);
      }
    }
    EndProcessing();

    return ret;
  }
  #endregion

  #region SetValues Method
  protected User SetValues(User current, User changes)
  {
    // Overwrite the changed properties in the entity
    // read from the database with the entity submitted by the user
    current.LoginId = string.IsNullOrWhiteSpace(changes.LoginId) ? current.LoginId : changes.LoginId;
    current.FirstName = string.IsNullOrWhiteSpace(changes.FirstName) ? current.FirstName : changes.FirstName;
    current.LastName = string.IsNullOrWhiteSpace(changes.LastName) ? current.LastName : changes.LastName;
    current.Email = string.IsNullOrWhiteSpace(changes.Email) ? current.Email : changes.Email;
    current.Password = string.IsNullOrWhiteSpace(changes.Password) ? current.Password : changes.Password;
    current.Phone = string.IsNullOrWhiteSpace(changes.Phone) ? current.Phone : changes.Phone;
    current.PhoneType = string.IsNullOrWhiteSpace(changes.PhoneType) ? current.PhoneType : changes.PhoneType;
    current.IsFullTime = changes.IsFullTime;
    current.IsEnrolledIn401k = changes.IsEnrolledIn401k;
    current.IsEnrolledInHealthCare = changes.IsEnrolledInHealthCare;
    current.IsEnrolledInHSA = changes.IsEnrolledInHSA;
    current.IsEnrolledInFlexTime = changes.IsEnrolledInFlexTime;
    current.IsActive = changes.IsActive;
    current.BirthDate = changes.BirthDate == DateTime.MinValue ? current.BirthDate : changes.BirthDate;
    current.StartTime = changes.StartTime == new TimeSpan() ? current.StartTime : changes.StartTime;

    return current;
  }
  #endregion

  #region GetPhoneTypes Method
  public async Task<ObservableCollection<string>> GetPhoneTypes()
  {
    if (_PhoneTypeRepository != null) {
      var list = await _PhoneTypeRepository.GetAsync();

      PhoneTypesList = new ObservableCollection<string>(list.Select(row => row.TypeDescription));
    }

    return PhoneTypesList;
  }
  #endregion

  #region CreateEmpty Method
  public User CreateEmpty()
  {
    User ret = new() {
      UserId = 0,
      LoginId = "BugsBunny123",
      FirstName = "Bugs",
      LastName = "Bunny",
      Email = "BugsBunny@acme.com",
      Password = "P@ssw0rd!",
      Phone = "(615) 123-9876",
      PhoneType = "Mobile",
      IsFullTime = true,
      IsEnrolledIn401k = true,
      IsEnrolledInHealthCare = false,
      IsEnrolledInHSA = false,
      IsEnrolledInFlexTime = true,
      IsActive = true,
      BirthDate = Convert.ToDateTime("7/27/1940"),
      StartTime = new TimeSpan(6, 0, 0),
    };

    return ret;
  }
  #endregion
}
