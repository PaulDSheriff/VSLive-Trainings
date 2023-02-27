namespace AdvWorksAPI.EntityLayer;

public partial class Customer
{
  public Customer()
  {
    Title = string.Empty;
    FirstName = string.Empty;
    MiddleName = string.Empty;
    LastName = string.Empty;
    CompanyName = string.Empty;
    EmailAddress = string.Empty;
    Phone = string.Empty;
  }

  public int CustomerID { get; set; }
  public string? Title { get; set; }
  public string FirstName { get; set; }
  public string? MiddleName { get; set; }
  public string LastName { get; set; }
  public string? CompanyName { get; set; }
  public string? EmailAddress { get; set; }
  public string? Phone { get; set; }
  public DateTime ModifiedDate { get; set; }

  #region ToString Override
  public override string ToString()
  {
    return $"{LastName}, {FirstName} ({CustomerID})";
  }
  #endregion
}
