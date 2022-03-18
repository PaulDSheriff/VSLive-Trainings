using System.Collections.Generic;
using System.Linq;
using AdvWorks.DataLayer;
using AdvWorks.EntityLayer;

namespace AdvWorks.ViewModelLayer
{
  public class ProductViewModel
  {
    #region Constructors
    /// <summary>
    ///  NOTE: You need to have a parameterless constructor for Post-Backs in MVC    
    /// </summary>
    public ProductViewModel()
    {
    }

    public ProductViewModel(AdventureWorksLTDbContext context)
    {
      _DbContext = context;
    }
    #endregion

    #region Properties
    private AdventureWorksLTDbContext _DbContext { get; set; }
    public List<Product> Products { get; set; }
    #endregion

    #region LoadProducts Method
    public virtual void LoadProducts()
    {
      Products = _DbContext.Products.OrderBy(p => p.Name).ToList();
    }
    #endregion
  }
}