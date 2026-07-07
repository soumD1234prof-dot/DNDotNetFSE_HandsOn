namespace InventoryManagementSystem;
 
public class Product
{
    public int ProductId { get; }
    public string ProductName { get; set; }
    public int Quantity { get; set; }
    public double Price { get; set; }
 
    public Product(int productId, string productName, int quantity, double price)
    {
        ProductId = productId;
        ProductName = productName;
        Quantity = quantity;
        Price = price;
    }
 
    public void Display()
    {
        Console.WriteLine($"{ProductId,-10}{ProductName,-20}{Quantity,-10}${Price:F2}");
    }
}