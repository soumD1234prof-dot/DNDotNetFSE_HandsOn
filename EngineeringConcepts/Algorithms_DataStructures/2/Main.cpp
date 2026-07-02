#include "Product.h"
#include "SearchAlgos.h"
#include <iostream>
#include <vector>
#include <algorithm>
 
int main() {
    std::vector<Product> products = {
        Product(105, "Wireless Mouse", "Electronics"),
        Product(102, "Yoga Mat", "Fitness"),
        Product(110, "Bluetooth Speaker", "Electronics"),
        Product(101, "Coffee Mug", "Home"),
        Product(108, "Running Shoes", "Fitness"),
        Product(103, "Desk Lamp", "Home"),
        Product(107, "Backpack", "Accessories"),
        Product(104, "Water Bottle", "Fitness"),
        Product(106, "Notebook", "Stationery"),
        Product(109, "Phone Case", "Accessories")
    };
 
    std::vector<Product> sortedProducts = products;
    std::sort(sortedProducts.begin(), sortedProducts.end(),
              [](const Product& a, const Product& b) {
                  return a.getProductId() < b.getProductId();
              });
 
    std::cout << "\nUnsorted list (used for linear search):" << std::endl;
    for (const auto& p : products) p.display();
 
    std::cout << "\nSorted list (used for binary search):" << std::endl;
    for (const auto& p : sortedProducts) p.display();
 
    int targetId = 107;
    long long linearComparisons = 0;
    long long binaryComparisons = 0;
 
    int linearIndex = linearSearch(products, targetId, linearComparisons);
    int binaryIndex = binarySearch(sortedProducts, targetId, binaryComparisons);
 
    std::cout << "\nSearching for productId " << targetId << ":" << std::endl;
    std::cout << "\nLinear search -> index " << linearIndex
              << " (comparisons: " << linearComparisons << ")" << std::endl;
    std::cout << "Binary search -> index " << binaryIndex
              << " (comparisons: " << binaryComparisons << ")" << std::endl;
 
    int missingId = 999;
    long long linearMissComparisons = 0;
    long long binaryMissComparisons = 0;
 
    linearSearch(products, missingId, linearMissComparisons);
    binarySearch(sortedProducts, missingId, binaryMissComparisons);
 
    std::cout << "\nSearching for missing productId " << missingId << ":" << std::endl;
    std::cout << "\nLinear search comparisons: " << linearMissComparisons << std::endl;
    std::cout << "Binary search comparisons: " << binaryMissComparisons << std::endl;
 
    return 0;
}