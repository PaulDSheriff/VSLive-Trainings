using System.Text;

namespace LINQSamples;

public class Sample08 {
  /// <summary>
  /// Create an anonymous class from selected product properties
  /// </summary>
  public static void AnonymousClassMethod() {
    List<Product> products = ProductRepository.GetAll();
    StringBuilder sb = new(2048);

    // Write Method Syntax Here
    var list = products.Select(row => new {
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
