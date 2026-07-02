#ifndef INVENTORY_H
#define INVENTORY_H
 
#include "Product.h"
#include <unordered_map>
#include <string>
 
class Inventory {
public:
    bool addProduct(int id, const std::string& name, int qty, double price);
    bool updateQuantity(int id, int newQty);
    bool updatePrice(int id, double newPrice);
    bool deleteProduct(int id);
    Product* findProduct(int id);
    void displayAll() const;
    int size() const;
 
private:
    std::unordered_map<int, Product> products;
};
 
#endif