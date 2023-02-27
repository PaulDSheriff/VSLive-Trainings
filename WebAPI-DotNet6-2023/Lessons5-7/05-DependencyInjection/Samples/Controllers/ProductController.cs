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
  public ProductController(IRepository<Product> repo)
  {
    _Repo = repo;
  }

  [HttpGet]
  [ProducesResponseType(StatusCodes.Status200OK)]
  [ProducesResponseType(StatusCodes.Status404NotFound)]
  public ActionResult<IEnumerable<Product>> Get()
  {
    List<Product> list;

    // Get all data
    list = _Repo.Get();

    if (list != null && list.Count > 0) {
      return StatusCode(StatusCodes.Status200OK, list);
    }
    else {
      return StatusCode(StatusCodes.Status404NotFound, "No Products are available.");
    }
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
