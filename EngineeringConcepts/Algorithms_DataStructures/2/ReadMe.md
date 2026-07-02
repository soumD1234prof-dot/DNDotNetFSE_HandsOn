# Search Optimization — Linear Search vs Binary Search
 
## Big O Notation
 
Big O describes how an algorithm's runtime grows as input size (`n`) grows,
ignoring hardware/language-specific constants. It lets you compare
algorithms independent of machine speed — useful for predicting how search
will scale as the product catalog grows.
 
- **Best case** — the fewest operations possible (e.g. target is the very
  first element checked).
- **Average case** — expected operations across typical/random inputs.
- **Worst case** — the most operations possible (e.g. target is absent, or
  is the last element checked). This is what Big O notation usually
  describes, since it's the guaranteed upper bound.
## Implementation
 
- `Product` — holds `productId`, `productName`, `category`.
- `linearSearch()` — scans a `std::vector<Product>` (unsorted) sequentially.
- `binarySearch()` — repeatedly halves the search range on a
  `std::vector<Product>` sorted by `productId`.
- `main.cpp` — builds both an unsorted and a sorted product list, runs
  both algorithms against the same target ID, and prints the number of
  comparisons each one took.
## Build & Run
 
```bash
g++ Product.cpp SearchAlgorithms.cpp main.cpp -o search_demo
./search_demo
```
 
## Complexity Comparison
 
| Algorithm      | Best   | Average  | Worst    | Requires sorted data?  |
|----------------|--------|----------|----------|------------------------|
| Linear Search  | O(1)   | O(n)     | O(n)     | No                     |
| Binary Search  | O(1)   | O(log n) | O(log n) | Yes                    |
 
## Which fits an e-commerce search better?
 
**Binary search**, for ID/SKU-style exact-match lookups — the catalog is
large and read-heavy, and O(log n) scales far better than O(n) as the
product count grows (e.g. ~20 comparisons vs up to 1,000,000 comparisons
for a catalog of 1,000,000 items).
 
The trade-off: binary search requires the data to be sorted, and keeping
it sorted has its own cost on every insert/delete. In practice, this is
why real e-commerce platforms don't binary-search a raw array at all —
they use **indexed structures** (database B-tree indexes, or hash-based
indexes/search engines like Elasticsearch) that maintain sorted/indexed
order automatically. Binary search here is a stand-in that demonstrates
the same underlying principle those systems rely on.