INVENTORY MANAGEMENT SYSTEM
=====================================
 
 
1. WHY DATA STRUCTURES AND ALGORITHMS MATTER
---------------------------------------------------
 
A warehouse inventory system is not just "a list of products" - it is a list
that is constantly searched, updated, and modified, often thousands of times
a day, and often containing thousands or millions of distinct items.
 
If products were simply stored in a plain unsorted list and every operation
(look up a product, update its stock count, remove a discontinued item) had
to scan through the entire list one item at a time, performance would
degrade badly as the warehouse's catalog grows. A system that feels
instant with 100 products could become noticeably slow with 100,000
products, and unusable at a million.
 
The choice of data structure directly determines:
  - How fast you can find a specific product (by ID/SKU)
  - How fast you can add a new product or remove one
  - How fast you can update stock levels, which in a warehouse happens
    constantly (every sale, restock, or shipment changes a quantity)
  - How much memory the system consumes
  - How predictable/stable performance is as the catalog grows
 
This is why picking the right structure up front, rather than defaulting
to "just use a list," matters for a real inventory system.
 
 
2. DATA STRUCTURES CONSIDERED
-------------------------------
 
a) Array / std::vector (unsorted)
   - Add: fast (append to the end)
   - Find/Update/Delete: slow, requires scanning every element to find a
     matching product ID
   - Simple, but does not scale well for frequent lookups
 
b) Array / std::vector (sorted by productId)
   - Find: fast, via binary search
   - Add/Delete: slow, because inserting or removing an element in the
     middle requires shifting every subsequent element
   - Good for read-heavy, write-rare scenarios; not ideal here since
     warehouses add/remove/update stock constantly
 
c) Linked List
   - Add/Delete: fast once you already have a reference to the node
   - Find: slow, no way to jump directly to an element, must walk the list
   - Rarely a good default choice for lookup-heavy systems
 
d) Hash Map / Hash Table
   - Add/Find/Update/Delete: all fast on average, because the product ID
     is used to compute directly where the item lives, without scanning
   - Trade-off: does not keep products in any particular order
   - This is the structure best suited to an inventory system, where the
     product ID is a natural, unique key and most operations are
     "look up / modify a specific product by its ID"
 
e) Balanced Binary Search Tree
   - Add/Find/Update/Delete: all reliably fast, with guaranteed
     performance even in unusual/adversarial cases
   - Bonus: keeps products sorted by ID automatically, useful if the
     system needs to frequently display or export products in ID order
   - Slightly slower in typical/average cases than a hash map
 
CHOICE MADE FOR THIS IMPLEMENTATION: Hash Map (std::unordered_map<int,
Product>), keyed by productId.
 
Reasoning: the dominant operations described in the scenario are "add a
product," "update a product by ID," and "delete a product by ID" - all
identity-based lookups by a unique key, which is exactly the case a hash
map is built for. Sorted order was not a requirement here, so the
ordering trade-off of a hash map is acceptable.
 
 
3. TIME COMPLEXITY ANALYSIS
------------------------------
 
Using std::unordered_map<int, Product> keyed by productId:
 
  Operation         Average Case      Worst Case      Notes
  ---------         ------------      ----------      -----
  Add product       O(1)              O(n)            Worst case only
                                                        happens if many
                                                        keys collide into
                                                        the same bucket
  Find product       O(1)              O(n)           Same as above
  Update product     O(1)              O(n)            Find + in-place
                                                        modification
  Delete product      O(1)             O(n)            Find + bucket
                                                        removal
 
Why average case is O(1):
A hash map computes a "hash" of the key (the productId) and uses it to
jump almost directly to the bucket where that item lives, rather than
searching through other items. With a reasonable number of buckets and a
decent hash function (which std::unordered_map provides by default for
int keys), collisions are rare, so in practice each operation takes
roughly constant time regardless of how many products are in the system.
 
Why worst case is O(n):
If many different product IDs happened to hash into the same bucket
(a "collision"), that bucket internally degrades into something like a
small list that must be scanned. In a pathological case where every
product collides into one bucket, every operation would effectively
become a linear scan. This is rare in practice with integer keys and a
good hash function, but it is the theoretical worst case.
 
For comparison, if a sorted std::map (a balanced tree) had been used
instead, every operation would be a guaranteed O(log n), with no
average/worst-case gap - slightly slower than a hash map's typical case,
but far more predictable and consistent.
 
 
4. OPTIMIZATION CONSIDERATIONS
----------------------------------
 
- Load factor: std::unordered_map automatically grows and redistributes
  ("rehashes") its buckets once too many items are packed relative to
  the bucket count, keeping average performance close to O(1) as the
  inventory grows. If the approximate final size of the inventory is
  known in advance, calling reserve() up front avoids repeated
  rehashing while products are being loaded in bulk.
 
- Key choice: using productId (a unique integer) as the key, rather
  than something like productName (a string, possibly non-unique), keeps
  hashing cheap and avoids duplicate-key ambiguity entirely.
 
- Batch operations: if the warehouse needs to add or update many
  products at once (e.g. a nightly bulk stock file), reserving map
  capacity ahead of time and minimizing repeated lookups of the same key
  within a batch reduces overhead further.
 
- If sorted output or range queries become a frequent requirement (e.g.
  "list all products between ID 1000 and 2000," or "always display
  products in ID order"), it would be worth switching to std::map
  (a balanced tree) despite its slightly slower typical-case speed,
  since it guarantees both fast lookups and maintains sorted order,
  which a hash map cannot offer.
 
- For extremely large inventories distributed across multiple
  warehouses/servers, the next step beyond a single in-memory hash map
  would be an external database with indexing (e.g. a B-tree index in
  SQL, which behaves similarly to the balanced tree trade-off above but
  persists to disk and scales beyond a single machine's memory).