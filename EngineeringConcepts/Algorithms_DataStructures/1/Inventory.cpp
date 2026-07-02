#include "Inventory.h"
#include <iostream>
#include <iomanip>
 
bool Inventory::addProduct(int id, const std::string& name, int qty, double price) {
    if (products.find(id) != products.end()) {
        std::cout << "Product ID " << id << " already exists. Use update instead." << std::endl;
        return false;
    }
    products[id] = Product(id, name, qty, price);
    return true;
}
 
bool Inventory::updateQuantity(int id, int newQty) {
    auto it = products.find(id);
    if (it == products.end()) {
        std::cout << "Product ID " << id << " not found." << std::endl;
        return false;
    }
    it->second.setQuantity(newQty);
    return true;
}
 
bool Inventory::updatePrice(int id, double newPrice) {
    auto it = products.find(id);
    if (it == products.end()) {
        std::cout << "Product ID " << id << " not found." << std::endl;
        return false;
    }
    it->second.setPrice(newPrice);
    return true;
}
 
bool Inventory::deleteProduct(int id) {
    return products.erase(id) > 0;
}
 
Product* Inventory::findProduct(int id) {
    auto it = products.find(id);
    if (it == products.end()) {
        return nullptr;
    }
    return &(it->second);
}
 
void Inventory::displayAll() const {
    std::cout << std::left << std::setw(10) << "ID"
              << std::setw(20) << "Name"
              << std::setw(10) << "Qty"
              << "Price" << std::endl;
    std::cout << "--------------------------------------------" << std::endl;
    for (const auto& pair : products) {
        pair.second.display();
    }
}
 
int Inventory::size() const {
    return static_cast<int>(products.size());
}