using System.Net.Http.Json;

namespace Common.Library;
/// <summary>
/// All repository classes that make calls to Web API endpoints 
/// using the HttpClient class should inherit from this class
/// </summary>
public class HttpClientRepositoryBase
{
  #region Constructors
  public HttpClientRepositoryBase(HttpClient client)
  {
    HClient = client;
  }
  #endregion

  #region Public Properties
  /// <summary>
  /// Get/Set the instance of the HttpClient to use
  /// </summary>
  public HttpClient? HClient { get; set; }

  /// <summary>
  /// Get/Set the base address such as www.pdsa.com
  /// </summary>
  public string BaseAddress { get; set; } = string.Empty;
  /// <summary>
  /// Get/Set the UrlPath such as /api/Customer
  /// </summary>
  public string UrlPath { get; set; } = string.Empty;
  /// <summary>
  /// Get/Set the UrlSearchRoute such as /Search
  /// </summary>
  public string UrlSearchRoute { get; set; } = "/Search";
  /// <summary>
  /// Get/Set the UrlCountRoute such as /Count
  /// </summary>
  public string UrlCountRoute { get; set; } = "/Count";
  /// <summary>
  /// Get/Set the UrlQuery such as /api/Customer?firstName=p&lastName=s
  /// </summary>
  public string UrlQuery { get; set; } = string.Empty;
  /// <summary>
  /// Get/Set the UserAgent such as the application name "Customer Maintenance"
  /// </summary>
  public string UserAgent { get; set; } = string.Empty;
  /// <summary>
  /// Get/Set the content type you want returned such as "application/json"
  /// </summary>
  public string ContentType { get; set; } = "application/json";
  /// <summary>
  /// Get/Set any additional headers you want to send to the Web API server
  /// </summary>
  public Dictionary<string, string> Headers { get; set; } = new();
  #endregion

  #region FixUrlParts Method
  protected virtual void FixUrlParts()
  {
    // Make sure the BaseAddress does not end with a forward slash
    BaseAddress = BaseAddress.EndsWith('/') ? BaseAddress[..^1] : BaseAddress;
    // Make sure the UrlPath starts with a forward slash
    UrlPath = UrlPath.StartsWith('/') ? UrlPath : UrlPath[1..];
    // Make sure the UrlPath does not end with a forward slash
    UrlPath = UrlPath.EndsWith('/') ? UrlPath[..^1] : UrlPath;
  }
  #endregion

  #region BuildUrlQueryParameters Method
  public string BuildUrlQueryParameters(object search)
  {
    return BuildUrlQueryParameters(search, new());
  }

  public string BuildUrlQueryParameters(object search, List<string> excludeProperties)
  {
    List<string> queryParams = new();
    // Ensure all properties to exclude are lower case
    if (excludeProperties.Count > 0) {
      for (int index = 0; index < excludeProperties.Count; index++) {
        excludeProperties[index] = excludeProperties[index].ToLower();
      }
    }

    // Do NOT add properties decorated with [JsonIgnore]
    // to the URI Query
    var props = search.GetType().GetProperties().ToList();
    foreach (var item in props) {
      if (!excludeProperties.Contains(item.Name.ToLower())) {
        // Only get those properties with no [JsonIgnore] attribute
        if (!item.GetCustomAttributes(true).ToList().Where(a => a.ToString() == "System.Text.Json.Serialization.JsonIgnoreAttribute").Any()) {
          string? value = (string?)item.GetValue(search);
          if (!string.IsNullOrWhiteSpace(value)) {
            queryParams.Add($"{item.Name}={Uri.EscapeDataString(value)}");
          }
        }
      }
    }

    return string.Join('&', queryParams.ToArray());
  }
  #endregion

  #region SubmitAsyncQuery Methods
  /// <summary>
  /// Get all records from the data store
  /// </summary>
  /// <typeparam name="T">The type to return</typeparam>
  /// <returns>An object</returns>
  public async Task<T?> GetAsync<T>(string urlPath) where T : class, new()
  {
    UrlPath = urlPath;
    UrlQuery = string.Empty;
    return await SubmitAsyncQuery<T>(HttpClientRequestTypeEnum.Get, null);
  }

  /// <summary>
  /// Get a single record from the data store
  /// </summary>
  /// <typeparam name="T">The type to return</typeparam>
  /// <param name="id"></param>
  /// <returns>An object</returns>
  public async Task<T?> GetAsync<T>(string urlPath, string id) where T : class, new()
  {
    UrlPath = urlPath;
    UrlQuery = $"/{id}";
    return await SubmitAsyncQuery<T>(HttpClientRequestTypeEnum.Get, null);
  }

  public async Task<TEntity?> SearchAsync<TEntity, TSearch>(string urlPath, TSearch? search) where TEntity : class, new()
  {
    UrlPath = urlPath;
    UrlPath += UrlSearchRoute;
    if (search == null) {
      UrlQuery = string.Empty;
    }
    else {
      UrlPath += "?";
      UrlQuery = BuildUrlQueryParameters(search, new List<string>() { "SortExpression" });
    }

    return await SubmitAsyncQuery<TEntity>(HttpClientRequestTypeEnum.Get, null);
  }

  public async Task<T?> CountAsync<T, TSearch>(string urlPath, TSearch? search) where T : class, new()
  {
    UrlPath = urlPath;
    UrlPath += UrlCountRoute;
    if (search == null) {
      UrlQuery = string.Empty;
    }
    else {
      UrlQuery = BuildUrlQueryParameters(search);
      if (!string.IsNullOrWhiteSpace(UrlQuery)) {
        UrlPath += "?";
      }
    }

    return await SubmitAsyncQuery<T>(HttpClientRequestTypeEnum.Count, default);
  }

  public async Task<T?> PostAsync<T>(string urlPath, T? entity) where T : class, new()
  {
    UrlPath = urlPath;
    UrlQuery = string.Empty;
    return await SubmitAsyncQuery(HttpClientRequestTypeEnum.Post, entity);
  }

  public async Task<T?> PutAsync<T>(string urlPath, string id, T? entity) where T : class, new()
  {
    UrlPath = urlPath;
    UrlQuery = $"/{id}";

    return await SubmitAsyncQuery(HttpClientRequestTypeEnum.Put, entity);
  }

  public async Task<T?> DeleteAsync<T>(string urlPath, string id) where T : class, new()
  {
    UrlPath = urlPath;
    UrlQuery = $"/{id}";

    return await SubmitAsyncQuery<T>(HttpClientRequestTypeEnum.Delete, null);
  }

  protected async Task<T?> SubmitAsyncQuery<T>(HttpClientRequestTypeEnum requestType, T? payload) where T : class, new()
  {
    T? ret = null;
    HttpResponseMessage? resp = null;

    if (HClient == null) {
      throw new ArgumentNullException("HttpClient object is null.");
    }
    else {
      // Set the base address
      BaseAddress = HClient?.BaseAddress?.AbsoluteUri ?? string.Empty;

      // Make sure all URL parts are ready to submit
      FixUrlParts();

      try {
        // Open Path and Verify a Valid URI Address
        switch (requestType) {
          case HttpClientRequestTypeEnum.Get:
          case HttpClientRequestTypeEnum.Count:
            if (HClient != null) {
              resp = await HClient.GetAsync(UrlPath + UrlQuery);
            }
            break;
          case HttpClientRequestTypeEnum.Post:
            if (HClient != null) {
              resp = await HClient.PostAsJsonAsync(UrlPath, payload);
            }
            break;
          case HttpClientRequestTypeEnum.Put:
            if (HClient != null) {
              resp = await HClient.PutAsJsonAsync(UrlPath + UrlQuery, payload);
            }
            break;
          case HttpClientRequestTypeEnum.Delete:
            if (HClient != null) {
              resp = await HClient.DeleteAsync(UrlPath + UrlQuery);
            }
            break;
        }
        if (resp != null) {
          // Was the call successful?
          if (resp.IsSuccessStatusCode) {
            try {
              // Convert return value into a DataResponse object
              ret = await resp.Content.ReadFromJsonAsync<T>();
            }
            catch  {
              ret = null;
            }
          }          
        }       
      }      
      catch {
        ret = null;
      }
    }

    return ret;
  }
  #endregion
}
