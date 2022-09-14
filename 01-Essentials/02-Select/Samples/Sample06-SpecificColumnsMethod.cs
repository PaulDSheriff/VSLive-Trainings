using System.Text;

namespace LINQSamples;

public class Sample06 {
  /// <summary>
  /// Select a few specific properties from products and create new Product objects
  /// </summary>
  public static void GetSpecificColumnsMethod() {
    List<Product> products = ProductRepository.GetAll();
    List<Product> list;

    // Write Method Syntax Here
    list = products.Select(row => new Product
    {
      ProductID = row.ProductID,
      Name = row.Name,
      Size = row.Size
    }).ToList();

    // Display products
    foreach (Product product in list) {
      Console.Write(product);
    }

    // Display Total Count
    Console.WriteLine();
    Console.WriteLine($"Total Products: {list.Count}");

    // Pause for Results
    Console.ReadKey();
  }
}
