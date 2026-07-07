namespace InventoryManagementSystem;
 
public class Inventory
{
    private readonly Dictionary<int, Product> products = new Dictionary<int, Product>();
 
    public bool AddProduct(int id, string name, int qty, double price)
    {
        if (products.ContainsKey(id))
        {
            Console.WriteLine($"Product ID {id} already exists!! Use update instead.");
            return false;
        }
        products[id] = new Product(id, name, qty, price);
        return true;
    }
 
    public bool UpdateQuantity(int id, int newQty)
    {
        if (!products.TryGetValue(id, out Product? product))
        {
            Console.WriteLine($"Product ID {id} not found.");
            return false;
        }
        product.Quantity = newQty;
        return true;
    }
 
    public bool UpdatePrice(int id, double newPrice)
    {
        if (!products.TryGetValue(id, out Product? product))
        {
            Console.WriteLine($"Product ID {id} not found.");
            return false;
        }
        product.Price = newPrice;
        return true;
    }
 
    public bool DeleteProduct(int id)
    {
        return products.Remove(id);
    }
 
    public Product? FindProduct(int id)
    {
        products.TryGetValue(id, out Product? product);
        return product;
    }
 
    public void DisplayAll()
    {
        Console.WriteLine($"{"ID",-10}{"Name",-20}{"Qty",-10}Price");
        Console.WriteLine("--------------------------------------------");
        foreach (Product product in products.Values)
        {
            product.Display();
        }
    }
 
    public int Count => products.Count;
}