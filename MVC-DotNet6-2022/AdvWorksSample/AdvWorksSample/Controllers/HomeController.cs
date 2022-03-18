using AdvWorks.DataLayer;
using AdvWorks.ViewModelLayer;
using AdvWorksSample.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AdvWorksSample.Controllers {
  public class HomeController : Controller {
    private readonly AdventureWorksLTDbContext _DbContext;

    public HomeController(AdventureWorksLTDbContext context) {
      _DbContext = context;
    }

    public IActionResult Index() {
      ProductViewModel vm = new ProductViewModel(_DbContext);

      vm.LoadProducts();

      return View(vm);
    }

    public IActionResult Privacy() {
      return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error() {
      return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
  }
}