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
  public List<AdventureWorks.EntityLayer.Color> Get()
  {
    return new List<AdventureWorks.EntityLayer.Color>
    {
      new AdventureWorks.EntityLayer.Color {
         ColorName = "Black",
      },
      new AdventureWorks.EntityLayer.Color {
         ColorName = "Blue",
      },
      new AdventureWorks.EntityLayer.Color {
         ColorName = "Gray",
      },
      new AdventureWorks.EntityLayer.Color {
         ColorName = "Multi",
      },
      new AdventureWorks.EntityLayer.Color {
         ColorName = "Red",
      },
      new AdventureWorks.EntityLayer.Color {
         ColorName = "Silver",
      },
      new AdventureWorks.EntityLayer.Color {
         ColorName = "Silver/Black",
      },
      new AdventureWorks.EntityLayer.Color {
         ColorName = "White",
      },
      new AdventureWorks.EntityLayer.Color {
         ColorName = "Yellow",
      }
    };
  }
  #endregion
}