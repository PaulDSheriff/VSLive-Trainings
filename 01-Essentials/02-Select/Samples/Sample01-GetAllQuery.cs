using System.Text;

namespace LINQSamples;

public class Sample01 {
  /// <summary>
  /// Put all products into a collection using LINQ
  /// </summary>
  public static void GetAllQuery() {
    List<Product> products = ProductRepository.GetAll();
    List<Product> list;

    // Write Query Syntax Here
    list = (from row in products
            select row).ToList();

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