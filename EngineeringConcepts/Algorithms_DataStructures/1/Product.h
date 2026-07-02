#ifndef PRODUCT_H
#define PRODUCT_H
 
#include <string>
 
class Product {
public:
    Product();
    Product(int id, const std::string& name, int qty, double prc);
 
    int getProductId() const;
    std::string getProductName() const;
    int getQuantity() const;
    double getPrice() const;
 
    void setProductName(const std::string& name);
    void setQuantity(int qty);
    void setPrice(double prc);
 
    void display() const;
 
private:
    int productId;
    std::string productName;
    int quantity;
    double price;
};
 
#endif