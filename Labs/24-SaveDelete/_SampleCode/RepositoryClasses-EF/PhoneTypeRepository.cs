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
public partial class PhoneTypeRepository : IRepository<PhoneType>
{
  #region Constructor
  public PhoneTypeRepository(AdventureWorksDbContext context)
  {
    DbContextObject = context;
  }
  #endregion

  #region Public Properties
  public AdventureWorksDbContext DbContextObject { get; set; }
  #endregion
  
  #region GetAsync Method
  public async Task<ObservableCollection<PhoneType>> GetAsync()
  {
    IQueryable<PhoneType> query = DbContextObject.PhoneTypes;

    return new ObservableCollection<PhoneType>(await query.ToListAsync());
  }
  #endregion

  #region GetAsync(id) Method
  public async Task<PhoneType?> GetAsync(int id)
  {
    PhoneType? entity;

    entity = await DbContextObject.PhoneTypes.FindAsync(id);
   
    return entity;
  }
  #endregion


  #region InsertAsync Method
  public async Task<PhoneType?> InsertAsync(PhoneType? entity)
  {
    if (entity != null) {
      // Add new entity to Users DbSet
      DbContextObject.PhoneTypes.Add(entity);

      // Save changes in database
      await DbContextObject.SaveChangesAsync();
    }

    return entity;
  }
  #endregion

  #region UpdateAsync Method
  public async Task<PhoneType?> UpdateAsync(PhoneType? entity)
  {
    if (entity != null) {
      // Update entity in Users DbSet
      DbContextObject.PhoneTypes.Update(entity);

      // Save changes in database
      await DbContextObject.SaveChangesAsync();
    }

    return entity;
  }
  #endregion

  #region DeleteAsync Method
  public async Task<PhoneType?> DeleteAsync(PhoneType? entity)
  {
    PhoneType? ret = null;

    if (entity != null) {
      // Remove the record
      DbContextObject.PhoneTypes.Remove(entity);

      // Save changes in database
      await DbContextObject.SaveChangesAsync();

      ret = entity;
    }

    return ret;
  }
  #endregion
}
