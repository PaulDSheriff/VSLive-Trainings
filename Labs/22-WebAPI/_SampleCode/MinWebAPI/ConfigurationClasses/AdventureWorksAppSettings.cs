namespace AdventureWorks.MinWebAPI;

public class AdventureWorksAppSettings
{
  public AdventureWorksAppSettings()
  {
    ApplicationName = "Adventure Works";
    BaseWebAPIService = "http://localhost:5000:/api";
    InfoMessageDefault = "Problem Attempting to {Verb} using the {ClassName} API. Please Contact Your System Administrator.";
  }

  public string ApplicationName { get; set; }
  public string BaseWebAPIService { get; set; }
  public string InfoMessageDefault { get; set; }
}
