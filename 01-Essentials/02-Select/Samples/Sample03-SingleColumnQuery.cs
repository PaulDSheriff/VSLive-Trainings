using System.Text;

namespace LINQSamples;

public class Sample03 {
  /// <summary>
  /// Select a single column
  /// </summary>
  public static void GetSingleColumnQuery() {
    List<Product> products = ProductRepository.GetAll();
    List<string> list = new();

    // Write Query Syntax Here
    list.AddRange(from row in products
                  select row.Name);

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
