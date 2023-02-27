using AdvWorksAPI.EntityLayer;
using AdvWorksAPI.RepositoryLayer;
using Microsoft.AspNetCore.Mvc;

namespace AdvWorksAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
  [HttpGet]
  [ProducesResponseType(StatusCodes.Status200OK)]
  [ProducesResponseType(StatusCodes.Status404NotFound)]
  public ActionResult<IEnumerable<Product>> Get()
  {
    List<Product> list;

    // Get all data
    list = new ProductRepository().Get();

    if (list != null && list.Count > 0) {
      return StatusCode(StatusCodes.Status200OK, list);
    }
    else {
      return StatusCode(StatusCodes.Status404NotFound, "No Products are available.");
    }
  }

  [HttpGet]
  [Route("ByCategory/{categoryId}")]
  public ActionResult<IEnumerable<Product>> SearchByCategory(int categoryId)
  {
    // TODO: Code to locate data by category id
    Console.WriteLine(categoryId.ToString());

    return StatusCode(StatusCodes.Status200OK);
  }

  [HttpGet]
  [Route("ByNameAndPrice/Name/{name:alpha}/ListPrice/{listPrice:decimal:min(1)}")]
  public ActionResult<IEnumerable<Product>> ByNameAndPrice(string name, decimal listPrice)
  {
    // TODO: Search by name and price here
    Console.WriteLine(name);
    Console.WriteLine(listPrice.ToString());

    return StatusCode(StatusCodes.Status200OK);
  }

  [HttpGet]
  [Route("SearchByNameAndPrice")]
  public ActionResult<IEnumerable<Product>> SearchByNameAndPrice(string name, decimal listPrice)
  {
    // TODO: Search by name and price here
    Console.WriteLine(name);
    Console.WriteLine(listPrice.ToString());

    return StatusCode(StatusCodes.Status200OK);
  }


  [HttpGet("{id}")]
  [ProducesResponseType(StatusCodes.Status200OK)]
  [ProducesResponseType(StatusCodes.Status404NotFound)]
  public ActionResult<Product?> Get(int id)
  {
    ActionResult<Product?> ret;
    Product? entity;

    entity = new ProductRepository().Get(id);
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
