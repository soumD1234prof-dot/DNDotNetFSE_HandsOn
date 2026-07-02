#include "Inventory.h"
#include <iostream>
 
int main() {
    Inventory inventory;
 
    std::cout << "Adding demo products..." << std::endl;
    inventory.addProduct(101, "Steel Bolt", 500, 0.15);
    inventory.addProduct(102, "Hammer", 40, 12.99);
    inventory.addProduct(103, "Safety Helmet", 75, 8.50);
    inventory.addProduct(104, "Extension Cable", 60, 15.75);
 
    std::cout << "\nCurrent Inventory:" << std::endl;
    inventory.displayAll();
 
    std::cout << "\nUpdating quantity of product with ID 101..." << std::endl;
    inventory.updateQuantity(101, 450);
 
    std::cout << "\nUpdating price of product with ID 102..." << std::endl;
    inventory.updatePrice(102, 11.49);
 
    std::cout << "\nInventory after updates:" << std::endl;
    inventory.displayAll();
 
    std::cout << "\nDeleting product with ID 103..." << std::endl;
    inventory.deleteProduct(103);
 
    std::cout << "\nInventory after deletion:" << std::endl;
    inventory.displayAll();
 
    std::cout << "\nLooking up product with ID 104..." << std::endl;
    Product* found = inventory.findProduct(104);
    if (found != nullptr) {
        found->display();
    }
 
    std::cout << "\nAttempting to find deleted product with ID 103..." << std::endl;
    Product* notFound = inventory.findProduct(103);
    if (notFound == nullptr) {
        std::cout << "Product with ID 103 not found (expected)!" << std::endl;
    }
 
    std::cout << "\nTotal products in inventory: " << inventory.size() << std::endl;
 
    return 0;
}