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

  #region InsertAsync Method
  public async Task<Product?> InsertAsync(Product? entity)
  {
    Product? ret;

    // Attempt to insert the data
    ret = await PostAsync<Product>(URL_PATH, entity);

    return ret;
  }
  #endregion

  #region UpdateAsync Method
  public async Task<Product?> UpdateAsync(Product? entity)
  {
    Product? ret;
    string id;

    // Get the primary key to locate
    id = (entity?.ProductID ?? 0).ToString();

    // Attempt to update a record
    ret = await PutAsync<Product>(URL_PATH, id, entity);

    return ret;
  }
  #endregion

  #region DeleteAsync Method
  public async Task<Product?> DeleteAsync(Product? entity)
  {
    Product? ret;
    string id;

    // Get the primary key to locate
    id = (entity?.ProductID ?? 0).ToString();

    // Attempt to delete a record
    ret = await DeleteAsync<Product>(URL_PATH, id);

    return ret;
  }
  #endregion
}
