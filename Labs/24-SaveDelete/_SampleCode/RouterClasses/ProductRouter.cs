using AdventureWorks.EntityLayer;
using AdventureWorks.ViewModelLayer;
using Common.Library.Web;
using System.Collections.ObjectModel;

namespace AdventureWorks.MinWebAPI.RouterClasses;

public class ProductRouter : RouterBase
{
  #region Constructor
  public ProductRouter(ILogger<ProductRouter> logger) : base(logger)
  {
    UrlFragment = "api/Product";
    TagName = "Product Routes";
  }
  #endregion

  #region AddRoutes Method
  /// <summary>
  /// Add asynchronous routes
  /// </summary>
  /// <param name="app">A WebApplication object</param>
  public override void AddRoutes(WebApplication app)
  {
    app.MapGet($"/{UrlFragment}", async (ProductViewModel vm) => await GetAsync(vm))
       .WithTags(TagName)
       .Produces(200)
       .Produces<List<Product>>()
       .Produces(404)
       .Produces(500);

    app.MapGet($"/{UrlFragment}/{{id}}", async (int id, ProductViewModel vm) => await GetAsync(id, vm))
       .WithTags(TagName)
       .Produces(200)
       .Produces<Product>()
       .Produces(404);

    app.MapPost($"/{UrlFragment}", (Product entity, ProductViewModel vm) => Post(entity, vm))
      .WithTags(TagName)
      .Produces(201)
      .Produces<Product>()
      .Produces(404)
      .Produces(500);

    app.MapPut($"/{UrlFragment}/{{id}}", (int id, Product entity, ProductViewModel vm) => Put(id, entity, vm))
      .WithTags(TagName)
      .Produces(200)
      .Produces<Product>()
      .Produces(404)
      .Produces(500);

    app.MapDelete($"/{UrlFragment}/{{id}}", (int id, ProductViewModel vm) => Delete(id, vm))
      .WithTags(TagName)
      .Produces(200)
      .Produces<Product>()
      .Produces(404)
      .Produces(500);
  }
  #endregion

  #region GetAsync Method
  protected virtual async Task<IResult> GetAsync(ProductViewModel vm)
  {
    IResult ret = Results.Empty;
    ObservableCollection<Product> response = new();

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
  protected virtual async Task<IResult> GetAsync(int id, ProductViewModel vm)
  {
    IResult ret = Results.Empty;
    Product? response;

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
  protected virtual async Task<IResult> Post(Product? entity, ProductViewModel vm)
  {
    IResult ret;
    Product? response = new();

    // Serialize entity
    SerializeEntity(entity);

    try {
      // Attempt to insert into the data store
      response = await vm.InsertAsync(entity);

      // Success, return a '201 Created'
      ret = Results.Created($"/{UrlFragment}/{entity?.ProductID}", response);
    }
    catch (Exception ex) {
      // Error, return a '500 Internal Server Error'
      ret = HandleException(ex);
    }

    return ret;
  }
  #endregion

  #region Put Method
  protected virtual async Task<IResult> Put(int id, Product entity, ProductViewModel vm)
  {
    IResult ret;
    Product? response = new();

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
  protected virtual async Task<IResult> Delete(int id, ProductViewModel vm)
  {
    IResult ret;
    Product? response = new();

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
