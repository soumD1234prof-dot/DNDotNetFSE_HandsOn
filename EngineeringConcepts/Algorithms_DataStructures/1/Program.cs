namespace InventoryManagementSystem;
 
public static class Program
{
    public static void Main(string[] args)
    {
        var inventory = new Inventory();
 
        Console.WriteLine("\nAdding products...");
        inventory.AddProduct(101, "Steel Bolt", 500, 0.15);
        inventory.AddProduct(102, "Hammer", 40, 12.99);
        inventory.AddProduct(103, "Safety Helmet", 75, 8.50);
        inventory.AddProduct(104, "Extension Cable", 60, 15.75);
 
        Console.WriteLine("\nCurrent Inventory:");
        inventory.DisplayAll();
 
        Console.WriteLine("\nUpdating quantity of product with ID 101...");
        inventory.UpdateQuantity(101, 450);
 
        Console.WriteLine("Updating price of product with ID 102...");
        inventory.UpdatePrice(102, 11.49);
 
        Console.WriteLine("\nInventory after updates:");
        inventory.DisplayAll();
 
        Console.WriteLine("\nDeleting product with ID 103...");
        inventory.DeleteProduct(103);
 
        Console.WriteLine("\nInventory after deletion:");
        inventory.DisplayAll();
 
        Console.WriteLine("\nLooking up product with ID 104...");
        Product? found = inventory.FindProduct(104);
        found?.Display();
 
        Console.WriteLine("\nAttempting to find deleted product with ID 103...");
        Product? notFound = inventory.FindProduct(103);
        if (notFound is null)
        {
            Console.WriteLine("Product 103 not found! (expected)");
        }
 
        Console.WriteLine($"\nTotal products in inventory: {inventory.Count}");
    }
}