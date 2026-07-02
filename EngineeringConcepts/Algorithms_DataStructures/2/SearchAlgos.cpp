#include "SearchAlgos.h"
 
int linearSearch(const std::vector<Product>& products, int targetId, long long& comparisons) {
    comparisons = 0;
    for (size_t i = 0; i < products.size(); ++i) {
        ++comparisons;
        if (products[i].getProductId() == targetId) {
            return static_cast<int>(i);
        }
    }
    return -1;
}
 
int binarySearch(const std::vector<Product>& sortedProducts, int targetId, long long& comparisons) {
    comparisons = 0;
    int low = 0;
    int high = static_cast<int>(sortedProducts.size()) - 1;
 
    while (low <= high) {
        ++comparisons;
        int mid = low + (high - low) / 2;
        int midId = sortedProducts[mid].getProductId();
 
        if (midId == targetId) {
            return mid;
        } else if (midId < targetId) {
            low = mid + 1;
        } else {
            high = mid - 1;
        }
    }
    return -1;
}