using Common.Library;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace AdventureWorks.EntityLayer;

/// <summary>
/// This class contains properties that map to each field in the dbo.PhoneType table.
/// </summary>
[Table("PhoneType", Schema = "dbo")]
public partial class PhoneType : EntityBase
{
  /// <summary>
  /// Get/Set Phone Type Id
  /// </summary>
  [Key]
  [Display(Name = "Phone Type Id")]
  [Required(ErrorMessage = "{0} must be filled in.")]
  [Column("PhoneTypeId", TypeName = "int")]
  [JsonPropertyName("phoneTypeId")]
  public int PhoneTypeId { get; set; } 

  /// <summary>
  /// Get/Set Type Description
  /// </summary>
  [Display(Name = "Type Description")]
  [Required(ErrorMessage = "{0} must be filled in.")]
  [Column("TypeDescription", TypeName = "nvarchar")]
  [StringLength(20, MinimumLength=0, ErrorMessage = "{0} must be between {2} and {1} characters long.")]
  [JsonPropertyName("typeDescription")]
  public string TypeDescription { get; set; } = string.Empty;

  #region ToString Override
  public override string ToString() {
    return $"{TypeDescription}";
  }
  #endregion
}
