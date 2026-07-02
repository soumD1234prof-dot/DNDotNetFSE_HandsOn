#include "Product.h"
#include <iostream>
#include <iomanip>
 
Product::Product() : productId(0), productName(""), category("") {}
 
Product::Product(int id, const std::string& name, const std::string& cat)
    : productId(id), productName(name), category(cat) {}
 
int Product::getProductId() const {
    return productId;
}
 
std::string Product::getProductName() const {
    return productName;
}
 
std::string Product::getCategory() const {
    return category;
}
 
void Product::display() const {
    std::cout << std::left << std::setw(8) << productId
              << std::setw(20) << productName
              << category << std::endl;
}