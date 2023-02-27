namespace AdvWorksAPI.EntityLayer;

public class AdvWorksAPIDefaults
{
  public AdvWorksAPIDefaults()
  {
    Created = DateTime.Now;
    DefaultTitle = "Ms.";
    DefaultEmail = "LastName.FirstName@advworks.com";
  }

  public DateTime Created { get; set; }
  public string DefaultTitle { get; set; }
  public string DefaultEmail { get; set; }
}
