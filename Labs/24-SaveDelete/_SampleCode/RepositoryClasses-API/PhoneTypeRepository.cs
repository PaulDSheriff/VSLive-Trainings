using AdventureWorks.EntityLayer;
using Common.Library;
using System.Collections.ObjectModel;

namespace AdventureWorks.DataLayer;

public class PhoneTypeRepository : HttpClientRepositoryBase, IRepository<PhoneType>
{
  #region Constructors
  public PhoneTypeRepository(HttpClient client) : base(client)
  {
    UrlPath = URL_PATH;
    UserAgent = "AdventureWorks";
  }
  #endregion

  #region Private constants
  private const string URL_PATH = "/api/PhoneType";
  #endregion

  #region GetAsync Method
  public async Task<ObservableCollection<PhoneType>> GetAsync()
  {
    ObservableCollection<PhoneType>? list;

    // Attempt to get the data
    list = await GetAsync<ObservableCollection<PhoneType>>(URL_PATH);

    return list ?? new();
  }
  #endregion

  #region GetAsync(id) Method
  public async Task<PhoneType?> GetAsync(int id)
  {
    PhoneType? ret;

    // Attempt to get the data
    ret = await GetAsync<PhoneType>(URL_PATH, id.ToString());

    return ret;
  }
  #endregion

  #region InsertAsync Method
  public async Task<PhoneType?> InsertAsync(PhoneType? entity)
  {
    PhoneType? ret;

    // Attempt to insert the data
    ret = await PostAsync<PhoneType>(URL_PATH, entity);

    return ret;
  }
  #endregion

  #region UpdateAsync Method
  public async Task<PhoneType?> UpdateAsync(PhoneType? entity)
  {
    PhoneType? ret;
    string id;

    // Get the primary key to locate
    id = (entity?.PhoneTypeId ?? 0).ToString();

    // Attempt to update a record
    ret = await PutAsync<PhoneType>(URL_PATH, id, entity);

    return ret;
  }
  #endregion

  #region DeleteAsync Method
  public async Task<PhoneType?> DeleteAsync(PhoneType? entity)
  {
    PhoneType? ret;
    string id;

    // Get the primary key to locate
    id = (entity?.PhoneTypeId ?? 0).ToString();

    // Attempt to delete a record
    ret = await DeleteAsync<PhoneType>(URL_PATH, id);

    return ret;
  }
  #endregion
}
