using Common.Library;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace AdventureWorks.EntityLayer;

/// <summary>
/// This class contains properties that map to each field in the SalesLT.Product table.
/// </summary>
[Table("Product", Schema = "SalesLT")]
public partial class Product : EntityBase
{
  /// <summary>
  /// Get/Set Product Id
  /// </summary>
  [Key]
  [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
  [Display(Name = "Product Id")]
  [Required(ErrorMessage = "{0} must be filled in.")]
  [Column("ProductID", TypeName = "int")]
  [JsonPropertyName("productID")]
  public int ProductID { get; set; } 

  /// <summary>
  /// Get/Set Name
  /// </summary>
  [Display(Name = "Name")]
  [Required(ErrorMessage = "{0} must be filled in.")]
  [Column("Name", TypeName = "nvarchar")]
  [StringLength(50, MinimumLength=0, ErrorMessage = "{0} must be between {2} and {1} characters long.")]
  [JsonPropertyName("name")]
  public string Name { get; set; } = string.Empty;

  /// <summary>
  /// Get/Set Product Number
  /// </summary>
  [Display(Name = "Product Number")]
  [Required(ErrorMessage = "{0} must be filled in.")]
  [Column("ProductNumber", TypeName = "nvarchar")]
  [StringLength(25, MinimumLength=0, ErrorMessage = "{0} must be between {2} and {1} characters long.")]
  [JsonPropertyName("productNumber")]
  public string ProductNumber { get; set; } = string.Empty;

  /// <summary>
  /// Get/Set Color
  /// </summary>
  [Display(Name = "Color")]
  [Column("Color", TypeName = "nvarchar")]
  [StringLength(15, MinimumLength=0, ErrorMessage = "{0} must be between {2} and {1} characters long.")]
  [JsonPropertyName("color")]
  public string? Color { get; set; } 

  /// <summary>
  /// Get/Set Standard Cost
  /// </summary>
  [Display(Name = "Standard Cost")]
  [Required(ErrorMessage = "{0} must be filled in.")]
  [Column("StandardCost", TypeName = "money")]
  [DataType(DataType.Currency)]
  [Range(0.01, 9999999)]
  [JsonPropertyName("standardCost")]
  public decimal StandardCost { get; set; } 

  /// <summary>
  /// Get/Set List Price
  /// </summary>
  [Display(Name = "List Price")]
  [Required(ErrorMessage = "{0} must be filled in.")]
  [Column("ListPrice", TypeName = "money")]
  [DataType(DataType.Currency)]
  [Range(0.01, 9999999)]
  [JsonPropertyName("listPrice")]
  public decimal ListPrice { get; set; } 

  /// <summary>
  /// Get/Set Size
  /// </summary>
  [Display(Name = "Size")]
  [Column("Size", TypeName = "nvarchar")]
  [StringLength(5, MinimumLength=0, ErrorMessage = "{0} must be between {2} and {1} characters long.")]
  [JsonPropertyName("size")]
  public string? Size { get; set; } 

  /// <summary>
  /// Get/Set Weight
  /// </summary>
  [Display(Name = "Weight")]
  [Column("Weight", TypeName = "decimal")]
  [JsonPropertyName("weight")]
  public decimal? Weight { get; set; } 

  /// <summary>
  /// Get/Set Product Category Id
  /// </summary>
  [Display(Name = "Product Category Id")]
  [Column("ProductCategoryID", TypeName = "int")]
  [JsonPropertyName("productCategoryID")]
  public int? ProductCategoryID { get; set; } 

  /// <summary>
  /// Get/Set Product Model Id
  /// </summary>
  [Display(Name = "Product Model Id")]
  [Column("ProductModelID", TypeName = "int")]
  [JsonPropertyName("productModelID")]
  public int? ProductModelID { get; set; } 

  /// <summary>
  /// Get/Set Sell Start Date
  /// </summary>
  [Display(Name = "Sell Start Date")]
  [Required(ErrorMessage = "{0} must be filled in.")]
  [Column("SellStartDate", TypeName = "datetime")]
  [DataType(DataType.Date)]
  [JsonPropertyName("sellStartDate")]
  public DateTime SellStartDate { get; set; } 

  /// <summary>
  /// Get/Set Sell End Date
  /// </summary>
  [Display(Name = "Sell End Date")]
  [Column("SellEndDate", TypeName = "datetime")]
  [DataType(DataType.Date)]
  [JsonPropertyName("sellEndDate")]
  public DateTime? SellEndDate { get; set; } 

  /// <summary>
  /// Get/Set Discontinued Date
  /// </summary>
  [Display(Name = "Discontinued Date")]
  [Column("DiscontinuedDate", TypeName = "datetime")]
  [DataType(DataType.Date)]
  [JsonPropertyName("discontinuedDate")]
  public DateTime? DiscontinuedDate { get; set; } 

  /// <summary>
  /// Get/Set Modified Date
  /// </summary>
  [Display(Name = "Modified Date")]
  [Required(ErrorMessage = "{0} must be filled in.")]
  [Column("ModifiedDate", TypeName = "datetime")]
  [DataType(DataType.Date)]
  [JsonPropertyName("modifiedDate")]
  public DateTime ModifiedDate { get; set; }

  #region ToString Override
  public override string ToString() {
    return $"{Name}";
  }
  #endregion
}
