using AdventureWorks.EntityLayer;
using AdventureWorks.ViewModelLayer;
using Common.Library.Web;
using System.Collections.ObjectModel;

namespace AdventureWorks.MinWebAPI.RouterClasses;

public class PhoneTypeRouter : RouterBase
{
  #region Constructor
  public PhoneTypeRouter(ILogger<PhoneTypeRouter> logger) : base(logger)
  {
    UrlFragment = "api/PhoneType";
    TagName = "PhoneType Routes";
  }
  #endregion

  #region AddRoutes Method
  /// <summary>
  /// Add asynchronous routes
  /// </summary>
  /// <param name="app">A WebApplication object</param>
  public override void AddRoutes(WebApplication app)
  {
    app.MapGet($"/{UrlFragment}", async (PhoneTypeViewModel vm) => await GetAsync(vm))
       .WithTags(TagName)
       .Produces(200)
       .Produces<List<PhoneType>>()
       .Produces(404)
       .Produces(500);

    app.MapGet($"/{UrlFragment}/{{id}}", async (int id, PhoneTypeViewModel vm) => await GetAsync(id, vm))
       .WithTags(TagName)
       .Produces(200)
       .Produces<PhoneType>()
       .Produces(404);
  }
  #endregion

  #region GetAsync Method
  protected virtual async Task<IResult> GetAsync(PhoneTypeViewModel vm)
  {
    IResult ret = Results.Empty;
    ObservableCollection<PhoneType> response = new();

    try {
      // Attempt to get all rows in the data store
      response = await vm.GetAsync();

      if (response.Count > 0) {
        // Success, return a '200 OK'
        ret = Results.Ok(response);
      }
      else if (response.Count == 0) {
        // No data found, return '404 Not Found'
        ret = Results.NotFound(response);
      }
    }
    catch (Exception ex) {
      // Error, return a '500 Internal Server Error'
      ret = HandleException(ex);
    }

    return ret;
  }
  #endregion

  #region GetAsync(id) Method
  protected virtual async Task<IResult> GetAsync(int id, PhoneTypeViewModel vm)
  {
    IResult ret = Results.Empty;
    PhoneType? response;

    try {
      // Attempt to get a single row in the data store
      response = await vm.GetAsync(id);

      if (response != null) {
        // Success, return a '200 OK'
        ret = Results.Ok(response);
      }
      else if (response == null) {
        // No data found, return '404 Not Found'
        ret = Results.NotFound(response);
      }
    }
    catch (Exception ex) {
      // Error, return a '500 Internal Server Error'
      ret = HandleException(ex);
    }

    return ret;
  }
  #endregion
}
