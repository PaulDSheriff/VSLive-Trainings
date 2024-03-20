using AdventureWorks.EntityLayer;
using Common.Library;
using System.Collections.ObjectModel;

namespace AdventureWorks.DataLayer;

public class UserRepository : HttpClientRepositoryBase, IRepository<User>
{
  #region Constructors
  public UserRepository(HttpClient client) : base(client)
  {
    UrlPath = URL_PATH;
    UserAgent = "AdventureWorks";
  }
  #endregion

  #region Private constants
  private const string URL_PATH = "/api/User";
  #endregion

  #region GetAsync Method
  public async Task<ObservableCollection<User>> GetAsync()
  {
    ObservableCollection<User>? list;

    // Attempt to get the data
    list = await GetAsync<ObservableCollection<User>>(URL_PATH);

    return list ?? new();
  }
  #endregion

  #region GetAsync(id) Method
  public async Task<User?> GetAsync(int id)
  {
    User? ret;

    // Attempt to get the data
    ret = await GetAsync<User>(URL_PATH, id.ToString());

    return ret;
  }
  #endregion
}
