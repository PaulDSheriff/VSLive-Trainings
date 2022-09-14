using System.Text;

namespace LINQSamples;

public class Sample07 {
  /// <summary>
  /// Create an anonymous class from selected product properties
  /// </summary>
  public static void AnonymousClassQuery() {
    List<Product> products = ProductRepository.GetAll();
    StringBuilder sb = new(2048);

    // Write Query Syntax Here
    var list = (from row in products
                select new {
                  Identifier = row.ProductID,
                  ProductName = row.Name,
                  ProductSize = row.Size
                });

    // Loop through anonymous class
    foreach (var product in list) {
      sb.AppendLine($"Product ID: {product.Identifier}");
      sb.AppendLine($"   Product Name: {product.ProductName}");
      sb.AppendLine($"   Product Size: {product.ProductSize}");
    }

    Console.WriteLine(sb.ToString());
  }
}
