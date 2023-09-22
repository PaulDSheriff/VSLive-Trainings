using AdventureWorks.DataLayer;
using AdventureWorks.EntityLayer;
using Common.Library;
using System.Collections.ObjectModel;

namespace AdventureWorks.ViewModelLayer;

public class ProductViewModel : ViewModelBase
{
  #region Private Variables
  private ProductRepository _ProductRepository = new();
  private ObservableCollection<Product> _ProductList = new();
  private Product _ProductObject = new();
  private ColorRepository _ColorRepository = new();
  private ObservableCollection<Color> _ColorList = new();
  #endregion

  #region Public Properties
  public Product ProductObject
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

  public ObservableCollection<Color> ColorList
  {
    get { return _ColorList; }
    set
    {
      _ColorList = value;
      RaisePropertyChanged(nameof(ColorList));
    }
  }
  #endregion

  #region Get Method
  public ObservableCollection<Product> Get()
  {
    ProductList = new ObservableCollection<Product>(_ProductRepository.Get());

    return ProductList;
  }
  #endregion

  #region Get(id) Method
  /// <summary>
  /// Get a single Product object
  /// </summary>
  /// <param name="id">The ProductId to locate</param>
  /// <returns>An instance of a Product object</returns>
  public Product Get(int id)
  {
    try {
      // Get a Product from a data store
      var Product = _ProductRepository.Get(id);
      // Check to make sure you get something back
      // Otherwise, just return some mock data
      if (Product == null) {
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
      else {
        ProductObject = Product;
      }
    }
    catch (Exception ex) {
      System.Diagnostics.Debug.WriteLine(ex.ToString());
    }

    return _ProductObject;
  }
  #endregion

  #region GetColors Method
  public ObservableCollection<Color> GetColors()
  {
    ColorList = new ObservableCollection<Color>(_ColorRepository.Get());

    return ColorList;
  }
  #endregion
}
