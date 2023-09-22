using AdventureWorks.DataLayer;
using AdventureWorks.EntityLayer;
using Common.Library;
using System.Collections.ObjectModel;

namespace AdventureWorks.ViewModelLayer;

public class ProductViewModel : ViewModelBase
{
  #region Constructors
  public ProductViewModel()
  {
  }

  public ProductViewModel(ProductRepository repo)
  {
    Repository = repo;
  }
  #endregion

  #region Private Variables
  private ProductRepository? Repository;
  private ObservableCollection<Product> _ProductList = new();
  private Product? _ProductObject = new();
  #endregion

  #region Public Properties
  public Product? ProductObject
  {
    get { return _ProductObject; }
    set
    {
      _ProductObject = value;
      RaisePropertyChanged(nameof(ProductObject));
    }
  }

  public ObservableCollection<Product> ProductList
  {
    get { return _ProductList; }
    set
    {
      _ProductList = value;
      RaisePropertyChanged(nameof(ProductList));
    }
  }
  #endregion

  #region Get Method
  public ObservableCollection<Product> Get()
  {
    if (Repository != null) {
      ProductList = new ObservableCollection<Product>(Repository.Get());
    }

    return ProductList;
  }
  #endregion

  #region Get(id) Method
  /// <summary>
  /// Get a single Product object
  /// </summary>
  /// <param name="id">The ProductId to locate</param>
  /// <returns>An instance of a Product object</returns>
  public Product? Get(int id)
  {
    try {
      if (Repository != null) {
        // Get a Product from a data store
        ProductObject = Repository.Get(id);
      }
      else {
        // MOCK Data
        ProductObject = new Product {
          ProductID = id,
          Name = "A New Product",
          Color = "Black",
          StandardCost = 10,
          ListPrice = 20,
          SellStartDate = Convert.ToDateTime("7/1/2023"),
          Size = "LG"
        };
      }
    }
    catch (Exception ex) {
      System.Diagnostics.Debug.WriteLine(ex.ToString());
    }

    return ProductObject;
  }
  #endregion
}
