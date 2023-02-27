using AdvWorksAPI.EntityLayer;
using AdvWorksAPI.RepositoryLayer;
using Microsoft.AspNetCore.Mvc;

namespace AdvWorksAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CustomerController : ControllerBase
{
  [HttpGet]
  //[Route("")]
  //[Route("GetAllCustomers")]
  [ProducesResponseType(StatusCodes.Status200OK)]
  [ProducesResponseType(StatusCodes.Status404NotFound)]
  public ActionResult<IEnumerable<Customer>> Get()
  {
    ActionResult<IEnumerable<Customer>> ret;
    List<Customer> list;

    // Get all data
    list = new CustomerRepository().Get();

    if (list != null && list.Count > 0) {
      ret = StatusCode(StatusCodes.Status200OK, list);
    }
    else {
      ret = StatusCode(StatusCodes.Status404NotFound, "No Customers are available.");
    }

    return ret;
  }

  [HttpGet("{id}")]
  [ProducesResponseType(StatusCodes.Status200OK)]
  [ProducesResponseType(StatusCodes.Status404NotFound)]
  public ActionResult<Customer> Get(int id)
  {
    ActionResult<Customer> ret;
    Customer? entity;

    entity = new CustomerRepository().Get(id);
    if (entity != null) {
      // Found data, return '200 OK'
      ret = StatusCode(StatusCodes.Status200OK, entity);
    }
    else {
      // Did not find data, return '404 Not Found'
      ret = StatusCode(StatusCodes.Status404NotFound, $"Can't find Customer with a Customer Id of '{id}'.");
    }

    return ret;
  }

  [HttpGet]
  [Route("SearchByTitle")]
  [ProducesResponseType(StatusCodes.Status200OK)]
  [ProducesResponseType(StatusCodes.Status404NotFound)]
  public ActionResult<IEnumerable<Customer>> SearchByTitle(string title)
  {
    ActionResult<IEnumerable<Customer>> ret;
    List<Customer> list;

    // Get all data
    list = new CustomerRepository().Get()
      .Where(row => row.Title == title)
      .OrderBy(row => row.LastName).ToList();

    if (list != null && list.Count > 0) {
      ret = StatusCode(StatusCodes.Status200OK, list);
    }
    else {
      ret = StatusCode(StatusCodes.Status404NotFound, 
        $"No Customers found matching the title '{title}'.");
    }

    return ret;
  }

  [HttpGet]
  [Route("SearchByFirstLast/First/{first}/Last/{last}")]
  [ProducesResponseType(StatusCodes.Status200OK)]
  [ProducesResponseType(StatusCodes.Status404NotFound)]
  public ActionResult<IEnumerable<Customer>> SearchByFirstLast(string first, string last)
  {
    ActionResult<IEnumerable<Customer>> ret;
    List<Customer> list;

    // Get all data
    list = new CustomerRepository().Get()
      .Where(row => row.FirstName.Contains(first, StringComparison.InvariantCultureIgnoreCase) &&
             row.LastName.Contains(last, StringComparison.InvariantCultureIgnoreCase))
      .OrderBy(row => row.LastName).ToList();

    if (list != null && list.Count > 0) {
      ret = StatusCode(StatusCodes.Status200OK, list);
    }
    else {
      ret = StatusCode(StatusCodes.Status404NotFound,
        "No Customers found matching the criteria passed in.");
    }

    return ret;
  }
}
