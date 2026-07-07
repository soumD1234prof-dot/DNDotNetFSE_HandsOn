# Inventory Management System (C#)
 
A simple warehouse inventory system built in C#, using a hash map
(`Dictionary<int, Product>`) to store and manage products efficiently.
 
## Features
 
- Add new products with a unique product ID, name, quantity, and price
- Update a product's quantity or price by ID
- Delete a product by ID
- Look up a single product by ID
- Display the full inventory
## Project Structure
 
| File | Purpose |
|------|---------|
| `Product.cs` | Data model for a single inventory item (`ProductId`, `ProductName`, `Quantity`, `Price`) |
| `Inventory.cs` | Manages the product collection and exposes add/update/delete/find/display operations |
| `Program.cs` | Demo driver exercising every operation |
 
## Why a Dictionary?
 
Warehouse inventory operations are almost always "look up / modify a
specific product by its ID" — exactly the case a hash map is built for.
`Dictionary<int, Product>` uses `ProductId` as the key, giving average
constant-time access without needing to scan the whole collection.
 
The trade-off: a `Dictionary` does not preserve insertion order or sort
order, so items may print in a different order than they were added.
If sorted output were a requirement, `SortedDictionary<int, Product>`
would be the better fit at the cost of some speed.
 
## Time Complexity
 
| Operation | Average Case | Worst Case |
|-----------|--------------|------------|
| Add       | O(1)         | O(n)       |
| Find      | O(1)         | O(n)       |
| Update    | O(1)         | O(n)       |
| Delete    | O(1)         | O(n)       |
 
Average-case O(1) holds because a good hash function spreads keys
evenly across buckets, so each operation jumps almost directly to the
right bucket instead of scanning other entries. Worst case (O(n))
would only occur if many keys collided into the same bucket, which is
rare in practice with integer keys.
 
## Optimization Notes
 
- Pre-sizing the dictionary (`new Dictionary<int, Product>(capacity)`)
  avoids repeated internal resizing during bulk inserts.
- `TryGetValue()` is used throughout instead of `ContainsKey()` followed
  by a separate lookup, avoiding hashing the same key twice.
- For very large or distributed inventories, an indexed database table
  (e.g. via Entity Framework Core) would be the natural next step
  beyond a single in-memory `Dictionary`.
## Build & Run
 
```bash
dotnet run
```