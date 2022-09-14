using System.Text;

namespace LINQSamples;

public class Sample05 {
  /// <summary>
  /// Select a few specific properties from products and create new Product objects
  /// </summary>
  public static void GetSpecificColumnsQuery() {
    List<Product> products = ProductRepository.GetAll();
    List<Product> list;

    // Write Query Syntax Here
    list = (from row in products
            select new Product {
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
