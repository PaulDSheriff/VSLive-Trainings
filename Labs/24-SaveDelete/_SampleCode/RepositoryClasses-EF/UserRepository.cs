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
public partial class UserRepository : IRepository<User>
{
  #region Constructor
  public UserRepository(AdventureWorksDbContext context)
  {
    DbContextObject = context;
  }
  #endregion

  #region Public Properties
  public AdventureWorksDbContext DbContextObject { get; set; }
  #endregion

  #region GetAsync Method
  public async Task<ObservableCollection<User>> GetAsync()
  {
    IQueryable<User> query = DbContextObject.Users;

    return new ObservableCollection<User>(await query.ToListAsync());
  }
  #endregion

  #region GetAsync(id) Method
  public async Task<User?> GetAsync(int id)
  {
    User? entity;

    entity = await DbContextObject.Users.FindAsync(id);

    return entity;
  }
  #endregion

  #region InsertAsync Method
  public async Task<User?> InsertAsync(User? entity)
  {
    if (entity != null) {
      // Add new entity to Users DbSet
      DbContextObject.Users.Add(entity);

      // Save changes in database
      await DbContextObject.SaveChangesAsync();
    }

    return entity;
  }
  #endregion

  #region UpdateAsync Method
  public async Task<User?> UpdateAsync(User? entity)
  {
    if (entity != null) {
      // Update entity in Users DbSet
      DbContextObject.Users.Update(entity);

      // Save changes in database
      await DbContextObject.SaveChangesAsync();
    }

    return entity;
  }
  #endregion

  #region DeleteAsync Method
  public async Task<User?> DeleteAsync(User? entity)
  {
    User? ret = null;

    if (entity != null) {
      // Remove the record
      DbContextObject.Users.Remove(entity);

      // Save changes in database
      await DbContextObject.SaveChangesAsync();

      ret = entity;
    }

    return ret;
  }
  #endregion
}
