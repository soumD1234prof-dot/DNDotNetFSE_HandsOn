namespace SearchOpti;
 
public static class Program
{
    public static void Main(string[] args)
    {
        var products = new List<Product>
        {
            new Product(105, "Wireless Mouse", "Electronics"),
            new Product(102, "Yoga Mat", "Fitness"),
            new Product(110, "Bluetooth Speaker", "Electronics"),
            new Product(101, "Coffee Mug", "Home"),
            new Product(108, "Running Shoes", "Fitness"),
            new Product(103, "Desk Lamp", "Home"),
            new Product(107, "Backpack", "Accessories"),
            new Product(104, "Water Bottle", "Fitness"),
            new Product(106, "Notebook", "Stationery"),
            new Product(109, "Phone Case", "Accessories")
        };
 
        List<Product> sortedProducts = products
            .OrderBy(p => p.ProductId)
            .ToList();
 
        Console.WriteLine("\nUnsorted list (used for linear search):");
        foreach (var p in products) p.Display();
 
        Console.WriteLine("\nSorted list (used for binary search):");
        foreach (var p in sortedProducts) p.Display();
 
        int targetId = 107;
        int linearIndex = SearchAlgos.LinearSearch(products, targetId, out long linearComparisons);
        int binaryIndex = SearchAlgos.BinarySearch(sortedProducts, targetId, out long binaryComparisons);
 
        Console.WriteLine($"\nSearching for product ID {targetId}:");
        Console.WriteLine($"Linear search -> index {linearIndex} (comparisons: {linearComparisons})");
        Console.WriteLine($"Binary search -> index {binaryIndex} (comparisons: {binaryComparisons})");
 
        int missingId = 999;
        SearchAlgos.LinearSearch(products, missingId, out long linearMissComparisons);
        SearchAlgos.BinarySearch(sortedProducts, missingId, out long binaryMissComparisons);
 
        Console.WriteLine($"\nSearching for missing Product ID {missingId}:");
        Console.WriteLine($"Linear search comparisons: {linearMissComparisons}");
        Console.WriteLine($"Binary search comparisons: {binaryMissComparisons}");
    }
}