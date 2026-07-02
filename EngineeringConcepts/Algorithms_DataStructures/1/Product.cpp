#include "Product.h"
#include <iostream>
#include <iomanip>
 
Product::Product() : productId(0), productName(""), quantity(0), price(0.0) {}
 
Product::Product(int id, const std::string& name, int qty, double prc)
    : productId(id), productName(name), quantity(qty), price(prc) {}
 
int Product::getProductId() const {
    return productId;
}
 
std::string Product::getProductName() const {
    return productName;
}
 
int Product::getQuantity() const {
    return quantity;
}
 
double Product::getPrice() const {
    return price;
}
 
void Product::setProductName(const std::string& name) {
    productName = name;
}
 
void Product::setQuantity(int qty) {
    quantity = qty;
}
 
void Product::setPrice(double prc) {
    price = prc;
}
 
void Product::display() const {
    std::cout << std::left << std::setw(10) << productId
              << std::setw(20) << productName
              << std::setw(10) << quantity
              << "$" << std::fixed << std::setprecision(2) << price
              << std::endl;
}