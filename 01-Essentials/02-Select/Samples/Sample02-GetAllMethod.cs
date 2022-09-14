using System.Text;

namespace LINQSamples;

public class Sample02 {
  /// <summary>
  /// Put all products into a collection using LINQ
  /// </summary>
  public static void GetAllMethod() {
    List<Product> products = ProductRepository.GetAll();
    List<Product> list;

    // Write Method Syntax Here
    list = products.Select(row => row).ToList();

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
