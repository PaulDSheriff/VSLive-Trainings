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
}