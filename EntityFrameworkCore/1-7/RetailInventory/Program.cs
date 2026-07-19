using Microsoft.EntityFrameworkCore;
using var context = new AppDbContext();

// var electronics = new Category { Name = "Electronics" }; 
// var groceries = new Category { Name = "Groceries" };

// await context.Categories.AddRangeAsync(electronics, groceries);

// var product1 = new Product { Name = "Laptop", Price = 75000, Category = electronics }; 
// var product2 = new Product { Name = "Rice Bag", Price = 1200, Category = groceries };

// await context.Products.AddRangeAsync(product1, product2); 
// await context.SaveChangesAsync();



// //retrieve all products (similar to SELECT *)
// var products = await context.Products.ToListAsync();  
// foreach (var p in products)
//     Console.WriteLine($"{p.Name} - ₹{p.Price}");

// //find by primary key (ID)
// var product = await context.Products.FindAsync(1); 
// Console.WriteLine($"Found: {product?.Name}");

// //FirstOrDefault with Condition 
// var expensive = await context.Products.FirstOrDefaultAsync(p => p.Price > 50000); 
// Console.WriteLine($"Expensive: {expensive?.Name}");



// //updating a product
// var product = await context.Products.FirstOrDefaultAsync(p => p.Name == "Laptop"); 
// if (product != null) { 
// product.Price = 70000; 
// await context.SaveChangesAsync(); 
// }

// //deleting a product
// var toDelete = await context.Products.FirstOrDefaultAsync(p => p.Name == "Rice Bag"); 
// if (toDelete != null) { 
// context.Products.Remove(toDelete); 
// await context.SaveChangesAsync(); 
// }



//filter and sort
var filtered = await context.Products 
.Where(p => p.Price > 1000) 
.OrderByDescending(p => p.Price) 
.ToListAsync();

Console.WriteLine("Filtered & Sorted");
foreach (var p in filtered)
    Console.WriteLine($"{p.Name} - ₹{p.Price}");

//project into Data Transfer Object
var productDTOs = await context.Products 
.Select(p => new { p.Name, p.Price }) //creates an anonymous type
.ToListAsync();

Console.WriteLine("Product DTOs (Name & Price only)");
foreach (var p in productDTOs)
    Console.WriteLine($"{p.Name} - ₹{p.Price}");