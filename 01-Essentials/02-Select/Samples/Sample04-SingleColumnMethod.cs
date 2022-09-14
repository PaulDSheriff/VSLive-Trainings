using System.Text;

namespace LINQSamples;

public class Sample04 {
  /// <summary>
  /// Select a single column
  /// </summary>
  public static void GetSingleColumnMethod() {
    List<Product> products = ProductRepository.GetAll();
    List<string> list = new();

    // Write Method Syntax Here
    list.AddRange(products.Select(row => row.Name));

    // Display products
    foreach (string name in list) {
      Console.Write(name);
    }

    // Display Total Count
    Console.WriteLine();
    Console.WriteLine($"Total Products: {list.Count}");

    // Pause for Results
    Console.ReadKey();
  }
}
