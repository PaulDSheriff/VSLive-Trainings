using AdventureWorks.EntityLayer;
using Microsoft.EntityFrameworkCore;
using Common.Library;
using System.Collections.ObjectModel;

namespace AdventureWorks.DataLayer;

/// <summary>
/// This partial class contains the class definition, inheritance chain, 
/// constructors and properties.
/// This class makes async calls to your data store.
/// </summary>
public partial class ProductRepository : IRepository<Product>
{
  #region Constructor
  public ProductRepository(AdventureWorksDbContext context)
  {
    DbContextObject = context;
  }
  #endregion

  #region Public Properties
  public AdventureWorksDbContext DbContextObject { get; set; }
  #endregion
  
  #region GetAsync Method
  public async Task<ObservableCollection<Product>> GetAsync()
  {
    IQueryable<Product> query = DbContextObject.Products;

    return new ObservableCollection<Product>(await query.ToListAsync());
  }
  #endregion

  #region GetAsync(id) Method
  public async Task<Product?> GetAsync(int id)
  {
    Product? entity;

    entity = await DbContextObject.Products.FindAsync(id);
    
    return entity;
  }
  #endregion


  #region InsertAsync Method
  public async Task<Product?> InsertAsync(Product? entity)
  {
    if (entity != null) {
      // Add new entity to Users DbSet
      DbContextObject.Products.Add(entity);

      // Save changes in database
      await DbContextObject.SaveChangesAsync();
    }

    return entity;
  }
  #endregion

  #region UpdateAsync Method
  public async Task<Product?> UpdateAsync(Product? entity)
  {
    if (entity != null) {
      // Update entity in Users DbSet
      DbContextObject.Products.Update(entity);

      // Save changes in database
      await DbContextObject.SaveChangesAsync();
    }

    return entity;
  }
  #endregion

  #region DeleteAsync Method
  public async Task<Product?> DeleteAsync(Product? entity)
  {
    Product? ret = null;

    if (entity != null) {
      // Remove the record
      DbContextObject.Products.Remove(entity);

      // Save changes in database
      await DbContextObject.SaveChangesAsync();

      ret = entity;
    }

    return ret;
  }
  #endregion
}
