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
}
