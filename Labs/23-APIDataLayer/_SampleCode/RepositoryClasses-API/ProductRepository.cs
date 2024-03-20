using AdventureWorks.EntityLayer;
using Common.Library;
using System.Collections.ObjectModel;

namespace AdventureWorks.DataLayer;

public class ProductRepository : HttpClientRepositoryBase, IRepository<Product>
{
  #region Constructors
  public ProductRepository(HttpClient client) : base(client)
  {
    UrlPath = URL_PATH;
    UserAgent = "AdventureWorks";
  }
  #endregion

  #region Private constants
  private const string URL_PATH = "/api/Product";
  #endregion

  #region GetAsync Method
  public async Task<ObservableCollection<Product>> GetAsync()
  {
    ObservableCollection<Product>? list;

    // Attempt to get the data
    list = await GetAsync<ObservableCollection<Product>>(URL_PATH);

    return list ?? new();
  }
  #endregion

  #region GetAsync(id) Method
  public async Task<Product?> GetAsync(int id)
  {
    Product? ret;

    // Attempt to get the data
    ret = await GetAsync<Product>(URL_PATH, id.ToString());

    return ret;
  }
  #endregion
}
