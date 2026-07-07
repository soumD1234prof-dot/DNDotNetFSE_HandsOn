# Search Optimization
 
Linear search vs. binary search over a product catalog, demonstrating
the practical difference between O(n) and O(log n) lookups.
 
## Big O Notation
 
Big O describes how an algorithm's runtime grows as input size (`n`)
grows, independent of hardware or language speed. It's what lets you
predict how a search will scale as a catalog grows, rather than just
guessing.
 
- **Best case** — fewest possible operations (target found immediately).
- **Average case** — expected operations across typical inputs.
- **Worst case** — most possible operations (target absent, or found
  last). This is what Big O notation typically describes, as the
  guaranteed upper bound.
## Features
 
- `Product` — holds `ProductId`, `ProductName`, `Category`
- `LinearSearch()` — scans an unsorted `List<Product>` sequentially
- `BinarySearch()` — repeatedly halves a `List<Product>` sorted by
  `ProductId`
- Both methods report the number of comparisons made, via an `out`
  parameter, so the performance difference is visible, not just claimed
## Build & Run
 
```bash
dotnet run
```
 
## Complexity Comparison
 
| Algorithm      | Best | Average  | Worst    | Requires sorted data? |
|----------------|------|----------|----------|------------------------|
| Linear Search  | O(1) | O(n)     | O(n)     | No                     |
| Binary Search  | O(1) | O(log n) | O(log n) | Yes                    |
 
## Which fits an e-commerce platform better?
 
**Binary search**, for exact-match ID/SKU lookups — catalogs are large
and read-heavy, and O(log n) scales far better than O(n) as the product
count grows.
 
The trade-off: binary search requires sorted data, and keeping data
sorted has its own cost on every insert/delete. This is why real
e-commerce platforms don't binary-search a raw list at all — they rely
on **indexed structures** (database B-tree indexes, or search engines
like Elasticsearch) that maintain sorted/indexed order automatically.
This project's binary search is a stand-in that demonstrates the same
underlying principle those systems are built on.