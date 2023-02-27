using AdvWorksAPI.EntityLayer;
using AdvWorksAPI.Interfaces;
using AdvWorksAPI.RepositoryLayer;
using Microsoft.AspNetCore.Mvc;

namespace AdvWorksAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
  private readonly IRepository<Product> _Repo;
  private readonly ILogger<ProductController> _Logger;

  public ProductController(IRepository<Product> repo, 
    ILogger<ProductController> logger)
  {
    _Repo = repo;
    _Logger = logger;
  }

  [HttpGet]
  [ProducesResponseType(StatusCodes.Status200OK)]
  [ProducesResponseType(StatusCodes.Status404NotFound)]
  [ProducesResponseType(StatusCodes.Status500InternalServerError)]
  public ActionResult<IEnumerable<Product>> Get()
  {
    ActionResult<IEnumerable<Product>> ret;
    List<Product> list;
    string msg = "No Products are available.";

    try {
      // Intentionally Cause an Exception
      throw new ApplicationException("ERROR!");

      // Get all data
      list = _Repo.Get();

      if (list != null && list.Count > 0) {
        return StatusCode(StatusCodes.Status200OK, list);
      }
      else {
        return StatusCode(StatusCodes.Status404NotFound, msg);
      }
    }
    catch (Exception ex) {
      msg = "Error in ProductController.Get()";
      msg += $"{Environment.NewLine}Message: {ex.Message}";
      msg += $"{Environment.NewLine}Source: {ex.Source}";

      _Logger.LogError(ex, "{msg}", msg);

      ret = StatusCode(StatusCodes.Status500InternalServerError,
        new ApplicationException("Error in Product API. Please Contact the System Administrator"));
    }

    return ret;
  }


  [HttpGet("{id}")]
  [ProducesResponseType(StatusCodes.Status200OK)]
  [ProducesResponseType(StatusCodes.Status404NotFound)]
  public ActionResult<Product?> Get(int id)
  {
    ActionResult<Product?> ret;
    Product? entity;

    entity = _Repo.Get(id);
    if (entity != null) {
      // Found data, return '200 OK'
      ret = StatusCode(StatusCodes.Status200OK, entity);
    }
    else {
      // Did not find data, return '404 Not Found'
      ret = StatusCode(StatusCodes.Status404NotFound, $"Can't find Product with a Product Id of '{id}'.");
    }

    return ret;
  }
}
