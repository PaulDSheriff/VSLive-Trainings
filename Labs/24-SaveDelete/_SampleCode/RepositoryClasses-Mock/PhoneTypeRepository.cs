using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using AdventureWorks.EntityLayer;
using Common.Library;

namespace AdventureWorks.DataLayer;

/// <summary>
/// This class creates some fake data for Phone Types.
/// </summary>
public partial class PhoneTypeRepository : IRepository<PhoneType>
{
  #region GetAsync Method
  /// <summary>
  /// Get all PhoneType objects
  /// </summary>
  /// <returns>A list of PhoneType objects</returns>
  public async Task<ObservableCollection<PhoneType>> GetAsync()
  {
    return await Task.FromResult(new ObservableCollection<PhoneType>
    {
      new() {
         PhoneTypeId = 1,
         TypeDescription = "Home",
      },
      new() {
         PhoneTypeId = 2,
         TypeDescription = "Mobile",
      },
      new() {
         PhoneTypeId = 3,
         TypeDescription = "Other",
      }
    });
  }
  #endregion

  #region GetAsync(id) Method
  /// <summary>
  /// Get a single PhoneType object
  /// </summary>
  /// <param name="id">The value to locate</param>
  /// <returns>A valid PhoneType object object, or null if not found</returns>
  public async Task<PhoneType?> GetAsync(int id)
  {
    ObservableCollection<PhoneType> list = await GetAsync();
    PhoneType? entity = list.Where(row => row.PhoneTypeId == id).FirstOrDefault();

    return await Task.FromResult(entity);
  }
  #endregion

  #region InsertAsync Method
  public async Task<PhoneType?> InsertAsync(PhoneType? entity)
  {
    return await Task.FromResult(new PhoneType());
  }
  #endregion

  #region UpdateAsync Method
  public async Task<PhoneType?> UpdateAsync(PhoneType? entity)
  {
    return await Task.FromResult(new PhoneType());
  }
  #endregion

  #region DeleteAsync Method
  public async Task<PhoneType?> DeleteAsync(PhoneType? entity)
  {
    return await Task.FromResult(new PhoneType());
  }
  #endregion
}