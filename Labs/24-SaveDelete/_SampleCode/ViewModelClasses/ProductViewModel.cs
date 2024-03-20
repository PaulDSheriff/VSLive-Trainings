using AdventureWorks.EntityLayer;
using Common.Library;
using System.Collections.ObjectModel;

namespace AdventureWorks.ViewModelLayer;

public class ProductViewModel : ViewModelBase
{
  #region Constructors
  public ProductViewModel() : base()
  {
  }

  public ProductViewModel(IRepository<Product> repo) : base()
  {
    Repository = repo;
  }
  #endregion

  #region Private Variables
  private readonly IRepository<Product>? Repository;
  private ObservableCollection<Product> _Products = new();
  private Product? _CurrentEntity = new();
  #endregion

  #region Public Properties
  public ObservableCollection<Product> Products
  {
    get { return _Products; }
    set
    {
      _Products = value;
      RaisePropertyChanged(nameof(Products));
    }
  }

  public Product? CurrentEntity
  {
    get { return _CurrentEntity; }
    set
    {
      _CurrentEntity = value;
      RaisePropertyChanged(nameof(CurrentEntity));
    }
  }
  #endregion

  #region GetAsync Method
  public async Task<ObservableCollection<Product>> GetAsync()
  {
    try {
      BeginProcessing();
      if (Repository == null) {
        LastErrorMessage = REPO_NOT_SET;
      }
      else {
        InfoMessage = "Please wait while loading products...";
        Products = new ObservableCollection<Product>(await Repository.GetAsync());
        RowsAffected = Products.Count;
        InfoMessage = $"Found {RowsAffected} Products";
      }
    }
    catch (Exception ex) {
      PublishException(ex);
    }
    EndProcessing();

    return Products;
  }
  #endregion

  #region GetAsync(id) Method
  /// <summary>
  /// Get a single Product object
  /// </summary>
  /// <param name="id">The ProductId to locate</param>
  /// <returns>An instance of a Product object</returns>
  public async Task<Product?> GetAsync(int id)
  {
    try {
      BeginProcessing();
      // Get a Product from a data store
      if (Repository != null) {
        CurrentEntity = await Repository.GetAsync(id);
      }
      else {
        LastErrorMessage = REPO_NOT_SET;

        // MOCK Data
        CurrentEntity = await Task.FromResult(new Product {
          ProductID = id,
          Name = "A New Product",
          Color = "Black",
          StandardCost = 10,
          ListPrice = 20,
          SellStartDate = Convert.ToDateTime("7/1/2023"),
          Size = "LG"
        });
      }

      InfoMessage = "Found the Product";
      RowsAffected = 1;
    }
    catch (Exception ex) {
      PublishException(ex);
    }
    EndProcessing();

    return CurrentEntity;
  }
  #endregion

  #region SaveAsync Method
  public async virtual Task<Product?> SaveAsync()
  {
    Product? ret;

    if (IsAdding) {
      ret = await InsertAsync();
    }
    else {
      ret = await UpdateAsync();
    }

    return ret;
  }
  #endregion

  #region InsertAsync Method
  public async Task<Product?> InsertAsync()
  {
    return await InsertAsync(CurrentEntity);
  }

  public async Task<Product?> InsertAsync(Product? entity)
  {
    Product? ret = null;

    // Validate Properties
    if (Validate<Product>(entity ?? new())) {
      // Ensure Repository Object is Set
      if (Repository == null) {
        LastErrorMessage = REPO_NOT_SET;
      }
      else {
        BeginProcessing();

        try {
          // Insert the new Product into data store
          CurrentEntity = await Repository.InsertAsync(entity);
          if (CurrentEntity != null) {
            IsAdding = false;
            RowsAffected = 1;

            // Add new entity to the collection
            Products.Add(CurrentEntity);

            ret = CurrentEntity;
          }
          else {
            RowsAffected = 0;

            // Don't allow a null CurrentEntity
            CurrentEntity = new();
          }
        }
        catch (Exception ex) {
          // Publish the exception here
          PublishException(ex);
        }
      }
    }
    EndProcessing();

    return ret;
  }
  #endregion

  #region UpdateAsync Method
  public async Task<Product?> UpdateAsync()
  {
    return await UpdateAsync(CurrentEntity?.ProductID ?? 0, CurrentEntity);
  }

  public async Task<Product?> UpdateAsync(int id, Product? entity)
  {
    Product? ret = null;

    // Validate Properties
    if (Validate<Product>(entity ?? new())) {
      // Ensure Repository Object is Set
      if (Repository == null) {
        LastErrorMessage = REPO_NOT_SET;
      }
      else {
        BeginProcessing();

        try {
          // Attempt to locate the data to update
          Product? current = await Repository.GetAsync(id);

          if (current != null) {
            // Update any common fields

            // Update 'current' with values passed in
            current = SetValues(current, entity ?? new());

            // Update the existing Product in the data store
            CurrentEntity = await Repository.UpdateAsync(current);
            if (CurrentEntity != null) {
              RowsAffected = 1;
            }
            else {
              RowsAffected = 0;

              // Don't allow a null CurrentEntity
              CurrentEntity = new();

              ret = CurrentEntity;
            }
          }
        }
        catch (Exception ex) {
          // Publish the exception here
          PublishException(ex);
        }
      }
    }
    EndProcessing();

    return ret;
  }
  #endregion

  #region DeleteAsync Method
  public async Task<Product?> DeleteAsync(int id)
  {
    Product? ret = new();

    // Ensure Repository Object is Set
    if (Repository == null) {
      LastErrorMessage = REPO_NOT_SET;
    }
    else {
      BeginProcessing();

      try {
        // Attempt to locate the data to delete
        Product? entity = await Repository.GetAsync(id);
        if (entity != null) {
          var tmp = await Repository.DeleteAsync(entity);
          if (tmp != null) {
            RowsAffected = 1;

            // Remove entity from collection
            if (Products.Count > 0) {
              Products.Remove(entity);
            }
          }
        }
      }
      catch (Exception ex) {
        // Publish the exception here
        PublishException(ex);
      }
    }
    EndProcessing();

    return ret;
  }
  #endregion

  #region SetValues Method
  protected Product SetValues(Product current, Product changes)
  {
    // Overwrite the changed properties in the entity
    // read from the database with the entity submitted by the user
    current.Name = string.IsNullOrWhiteSpace(changes.Name) ? current.Name : changes.Name;
    current.ProductNumber = string.IsNullOrWhiteSpace(changes.ProductNumber) ? current.ProductNumber : changes.ProductNumber;
    current.Color = string.IsNullOrWhiteSpace(changes.Color) ? current.Color : changes.Color;
    current.StandardCost = changes.StandardCost == 0 ? current.StandardCost : changes.StandardCost;
    current.ListPrice = changes.ListPrice == 0 ? current.ListPrice : changes.ListPrice;
    current.Size = string.IsNullOrWhiteSpace(changes.Size) ? current.Size : changes.Size;
    current.Weight = changes.Weight == 0 ? current.Weight : changes.Weight;
    current.ProductCategoryID = changes.ProductCategoryID == 0 ? current.ProductCategoryID : changes.ProductCategoryID;
    current.ProductModelID = changes.ProductModelID == 0 ? current.ProductModelID : changes.ProductModelID;
    current.SellStartDate = changes.SellStartDate == DateTime.MinValue ? current.SellStartDate : changes.SellStartDate;
    current.SellEndDate = changes.SellEndDate == DateTime.MinValue ? current.SellEndDate : changes.SellEndDate;
    current.DiscontinuedDate = changes.DiscontinuedDate == DateTime.MinValue ? current.DiscontinuedDate : changes.DiscontinuedDate;
    current.ModifiedDate = changes.ModifiedDate == DateTime.MinValue ? current.ModifiedDate : changes.ModifiedDate;

    return current;
  }
  #endregion
}
