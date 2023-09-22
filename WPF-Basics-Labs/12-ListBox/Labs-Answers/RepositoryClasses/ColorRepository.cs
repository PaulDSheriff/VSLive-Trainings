using System;
using System.Collections.Generic;
using System.Linq;
using AdventureWorks.EntityLayer;

namespace AdventureWorks.DataLayer;

/// <summary>
/// This class creates some fake data for Colors.
/// </summary>
public partial class ColorRepository
{
  #region Get Method
  /// <summary>
  /// Get all Color objects
  /// </summary>
  /// <returns>A list of Color objects</returns>
  public List<Color> Get()
  {
    return new List<Color>
    {
      new Color {
         ColorName = "Black",
      },
      new Color {
         ColorName = "Blue",
      },
      new Color {
         ColorName = "Gray",
      },
      new Color {
         ColorName = "Multi",
      },
      new Color {
         ColorName = "Red",
      },
      new Color {
         ColorName = "Silver",
      },
      new Color {
         ColorName = "Silver/Black",
      },
      new Color {
         ColorName = "White",
      },
      new Color {
         ColorName = "Yellow",
      }
    };
  }
  #endregion
}