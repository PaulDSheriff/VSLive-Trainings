using AdventureWorks.EntityLayer;
using AdventureWorks.ViewModelLayer;
using Common.Library.Web;
using System.Collections.ObjectModel;

namespace AdventureWorks.MinWebAPI.RouterClasses;

public class UserRouter : RouterBase
{
  #region Constructor
  public UserRouter(ILogger<UserRouter> logger) : base(logger)
  {
    UrlFragment = "api/User";
    TagName = "User Routes";
  }
  #endregion

  #region AddRoutes Method
  /// <summary>
  /// Add asynchronous routes
  /// </summary>
  /// <param name="app">A WebApplication object</param>
  public override void AddRoutes(WebApplication app)
  {
    app.MapGet($"/{UrlFragment}", async (UserViewModel vm) => await GetAsync(vm))
       .WithTags(TagName)
       .Produces(200)
       .Produces<List<User>>()
       .Produces(404)
       .Produces(500);

    app.MapGet($"/{UrlFragment}/{{id}}", async (int id, UserViewModel vm) => await GetAsync(id, vm))
       .WithTags(TagName)
       .Produces(200)
       .Produces<User>()
       .Produces(404);

    app.MapPost($"/{UrlFragment}", (User entity, UserViewModel vm) => Post(entity, vm))
      .WithTags(TagName)
      .Produces(201)
      .Produces<User>()
      .Produces(404)
      .Produces(500);

    app.MapPut($"/{UrlFragment}/{{id}}", (int id, User entity, UserViewModel vm) => Put(id, entity, vm))
      .WithTags(TagName)
      .Produces(200)
      .Produces<User>()
      .Produces(404)
      .Produces(500);

    app.MapDelete($"/{UrlFragment}/{{id}}", (int id, UserViewModel vm) => Delete(id, vm))
      .WithTags(TagName)
      .Produces(200)
      .Produces<User>()
      .Produces(404)
      .Produces(500);
  }
  #endregion

  #region GetAsync Method
  protected virtual async Task<IResult> GetAsync(UserViewModel vm)
  {
    IResult ret = Results.Empty;
    ObservableCollection<User> response = new();

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
  protected virtual async Task<IResult> GetAsync(int id, UserViewModel vm)
  {
    IResult ret = Results.Empty;
    User? response;

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

  #region Post Method
  protected virtual async Task<IResult> Post(User? entity, UserViewModel vm)
  {
    IResult ret;
    User? response = new();

    // Serialize entity
    SerializeEntity(entity);

    try {
      // Attempt to insert into the data store
      response = await vm.InsertAsync(entity);

      // Success, return a '201 Created'
      ret = Results.Created($"/{UrlFragment}/{entity?.UserId}", response);
    }
    catch (Exception ex) {
      // Error, return a '500 Internal Server Error'
      ret = HandleException(ex);
    }

    return ret;
  }
  #endregion

  #region Put Method
  protected virtual async Task<IResult> Put(int id, User entity, UserViewModel vm)
  {
    IResult ret;
    User? response = new();

    // Serialize entity
    SerializeEntity(entity);

    try {
      // Attempt to update the data store
      response = await vm.UpdateAsync(id, entity);

      // Success, return a '200 Ok'
      ret = Results.Ok(response);
    }
    catch (Exception ex) {
      // Error, return a '500 Internal Server Error'
      ret = HandleException(ex);
    }

    return ret;
  }
  #endregion

  #region Delete Method
  protected virtual async Task<IResult> Delete(int id, UserViewModel vm)
  {
    IResult ret;
    User? response = new();

    try {
      // Attempt to delete from the data store
      response = await vm.DeleteAsync(id);
      // Success, return a '204 No Content'
      ret = Results.NoContent();
    }
    catch (Exception ex) {
      // Error, return a '500 Internal Server Error'
      ret = HandleException(ex);
    }

    return ret;
  }
  #endregion
}
