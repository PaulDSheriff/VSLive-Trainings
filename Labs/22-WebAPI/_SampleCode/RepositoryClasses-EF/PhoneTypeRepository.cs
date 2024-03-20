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
}
