using System;
using System.Collections.Generic;
using System.Linq;
using AdventureWorks.EntityLayer;

namespace AdventureWorks.DataLayer;

/// <summary>
/// This class creates some fake data for Phone Types.
/// </summary>
public partial class PhoneTypeRepository
{
  #region Get Method
  /// <summary>
  /// Get all PhoneType objects
  /// </summary>
  /// <returns>A list of PhoneType objects</returns>
  public List<PhoneType> Get()
  {
    return new List<PhoneType>
    {
      new PhoneType {
         PhoneTypeId = 1,
         TypeDescription = "Home",
      },
      new PhoneType {
         PhoneTypeId = 2,
         TypeDescription = "Mobile",
      },
      new PhoneType {
         PhoneTypeId = 3,
         TypeDescription = "Other",
      }
    };
  }
  #endregion

  #region Get Method
  /// <summary>
  /// Get a single PhoneType object
  /// </summary>
  /// <param name="id">The value to locate</param>
  /// <returns>A valid PhoneType object object, or null if not found</returns>
  public PhoneType? Get(int id)
  {
    return Get().Where(row => row.PhoneTypeId == id).FirstOrDefault();
  }
  #endregion
}