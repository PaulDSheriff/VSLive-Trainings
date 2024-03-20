using AdventureWorks.EntityLayer;
using Common.Library;
using System.Collections.ObjectModel;

namespace AdventureWorks.ViewModelLayer;

public class PhoneTypeViewModel : ViewModelBase
{
  #region Constructors
  public PhoneTypeViewModel() : base()
  {
  }

  public PhoneTypeViewModel(IRepository<PhoneType> repo) : base()
  {
    Repository = repo;
  }
  #endregion

  #region Private Variables
  private readonly IRepository<PhoneType>? Repository;

  private ObservableCollection<PhoneType> _PhoneTypes = new();
  private PhoneType? _CurrentEntity = new();
  #endregion

  #region Public Properties
  public ObservableCollection<PhoneType> PhoneTypes
  {
    get { return _PhoneTypes; }
    set
    {
      _PhoneTypes = value;
      RaisePropertyChanged(nameof(PhoneTypes));
    }
  }

  public PhoneType? CurrentEntity
  {
    get { return _CurrentEntity; }
    set
    {
      _CurrentEntity = value;
      RaisePropertyChanged(nameof(CurrentEntity));
    }
  }
  #endregion

  #region GetAsync Method
  public async Task<ObservableCollection<PhoneType>> GetAsync()
  {   
    BeginProcessing();
    try {
      if (Repository == null) {
        LastErrorMessage = REPO_NOT_SET;
      }
      else {
        InfoMessage = "Please wait while loading Phone Types...";
        PhoneTypes = new ObservableCollection<PhoneType>(await Repository.GetAsync());
        RowsAffected = PhoneTypes.Count;
        InfoMessage = $"Found {RowsAffected} Phone Types";
      }
    }
    catch (Exception ex) {
      PublishException(ex);
    }
    EndProcessing();

    return PhoneTypes;
  }
  #endregion

  #region GetAsync(id) Method
  /// <summary>
  /// Get a single PhoneType object
  /// </summary>
  /// <param name="id">The PhoneTypeId to locate</param>
  /// <returns>An instance of a PhoneType object</returns>
  public async Task<PhoneType?> GetAsync(int id)
  {
    BeginProcessing();
    try {
      // Get a PhoneType from a data store
      if (Repository != null) {
        CurrentEntity = await Repository.GetAsync(id);
      }
      else {
        LastErrorMessage = REPO_NOT_SET;

        // MOCK Data
        CurrentEntity = await Task.FromResult(new PhoneType {
          PhoneTypeId = 1,
          TypeDescription = "Other"
        });
      }

      InfoMessage = "Found the Phone Type";
      RowsAffected = 1;
    }
    catch (Exception ex) {
      RowsAffected = 0;
      PublishException(ex);
    }
    EndProcessing();

    return CurrentEntity;
  }
  #endregion

  #region SaveAsync Method
  public async virtual Task<PhoneType?> SaveAsync()
  {
    // TODO: Write code to save data
    

    return await Task.FromResult(new PhoneType());
  }
  #endregion
}