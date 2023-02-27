using AdvWorksAPI.EntityLayer;
using AdvWorksAPI.RepositoryLayer;
using Microsoft.AspNetCore.Mvc;

namespace AdvWorksAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductEntityController : ControllerBase
{
  [HttpGet]
  public List<Product> Get()
  {
    List<Product> list;

    // Get all data
    list = new ProductRepository().Get();

    return list;
  }

  [HttpGet("{id}")]
  public Product? Get(int id)
  {
    Product? entity;

    entity = new ProductRepository().Get(id);

    return entity;
  }
}
