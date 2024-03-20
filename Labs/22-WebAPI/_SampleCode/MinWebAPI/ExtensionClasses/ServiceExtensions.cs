using AdventureWorks.DataLayer;
using AdventureWorks.EntityLayer;
using AdventureWorks.MinWebAPI.RouterClasses;
using AdventureWorks.ViewModelLayer;
using Common.Library;
using Common.Library.Web;
using Microsoft.EntityFrameworkCore;

namespace AdventureWorks.MinWebAPI.ExtensionClasses;

public static class ServiceExtension
{
  public static IServiceCollection ConfigureDataStore(this IServiceCollection services, string? cnn)
  {
    // Setup the DbContext object
    return services.AddDbContext<AdventureWorksDbContext>(
      options => options.UseSqlServer(cnn));
  }

  public static void AddRepositoryClasses(this IServiceCollection services)
  {
    // Add Repository Classes
    services.AddScoped<IRepository<PhoneType>, PhoneTypeRepository>();
    services.AddScoped<IRepository<User>, UserRepository>();
    services.AddScoped<IRepository<Product>, ProductRepository>();
  }
  
  public static void AddViewModelClasses(this IServiceCollection services)
  {
    // Add View Model Classes
    services.AddScoped<PhoneTypeViewModel>();
    services.AddScoped<UserViewModel>();
    services.AddScoped<ProductViewModel>();
  }
  
  public static void AddRouterClasses(this IServiceCollection services)
  {
    // Add "Router" classes as a service
    services.AddScoped<RouterBase, ErrorRouter>();

    services.AddScoped<RouterBase, PhoneTypeRouter>();
    services.AddScoped<RouterBase, UserRouter>();
    services.AddScoped<RouterBase, ProductRouter>();
  }

  public static void ConfigureOpenAPI(this IServiceCollection services)
  {
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    services.AddEndpointsApiExplorer();
    services.AddSwaggerGen();
  }  
}
