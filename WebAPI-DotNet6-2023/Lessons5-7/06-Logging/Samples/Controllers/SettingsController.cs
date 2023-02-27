using AdvWorksAPI.EntityLayer;
using AdvWorksAPI.RepositoryLayer;
using Microsoft.AspNetCore.Mvc;

namespace AdvWorksAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SettingsController : ControllerBase
{
  private readonly AdvWorksAPIDefaults _Settings;

  public SettingsController(AdvWorksAPIDefaults settings)
  {
    _Settings = settings;
  }

  [HttpGet]
  [Route("GetSettings")]
  [ProducesResponseType(StatusCodes.Status200OK)]
  public ActionResult<AdvWorksAPIDefaults> GetSettings()
  {
    return Ok(_Settings);
  }

  [HttpGet]
  [Route("GetSettingsAgain")]
  [ProducesResponseType(StatusCodes.Status200OK)]
  public ActionResult<AdvWorksAPIDefaults> GetSettingsAgain()
  {
    return Ok(_Settings);
  }
}
