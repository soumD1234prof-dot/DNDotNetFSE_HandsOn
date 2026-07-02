#ifndef SEARCH_ALGOS_H
#define SEARCH_ALGOS_H
 
#include "Product.h"
#include <vector>
 
int linearSearch(const std::vector<Product>& products, int targetId, long long& comparisons);
int binarySearch(const std::vector<Product>& sortedProducts, int targetId, long long& comparisons);
 
#endif