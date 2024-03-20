using AdventureWorks.EntityLayer;
using Common.Library;
using System.Collections.ObjectModel;
using System.Net;

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

  #region InsertAsync Method
  public async Task<User?> InsertAsync(User? entity)
  {
    User? ret;

    // Attempt to insert the data
    ret = await PostAsync<User>(URL_PATH, entity);

    return ret;
  }
  #endregion

  #region UpdateAsync Method
  public async Task<User?> UpdateAsync(User? entity)
  {
    User? ret;
    string id;

    // Get the primary key to locate
    id = (entity?.UserId ?? 0).ToString();

    // Attempt to update a record
    ret = await PutAsync<User>(URL_PATH, id, entity);

    return ret;
  }
  #endregion

  #region DeleteAsync Method
  public async Task<User?> DeleteAsync(User? entity)
  {
    User? ret;
    string id;

    // Get the primary key to locate
    id = (entity?.UserId ?? 0).ToString();

    // Attempt to delete a record
    ret = await DeleteAsync<User>(URL_PATH, id);

    return ret;
  }
  #endregion
}
