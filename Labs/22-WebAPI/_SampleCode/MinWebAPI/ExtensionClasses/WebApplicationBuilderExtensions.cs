namespace AdventureWorks.MinWebAPI.ExtensionClasses;

public static class WebApplicationBuilderExtensions
{
  public static AdventureWorksAppSettings ConfigureGlobalSettings(this WebApplicationBuilder builder)
  {
    // Configure Global Settings
    builder.Services.AddSingleton<AdventureWorksAppSettings, AdventureWorksAppSettings>();

    // Read "AdventureWorksAppSettings" section and add as a singleton
    AdventureWorksAppSettings settings = new();
    builder.Configuration.GetSection("AdventureWorksAppSettings").Bind(settings);
    builder.Services.AddSingleton<AdventureWorksAppSettings>(settings);

    return settings;
  }
}
