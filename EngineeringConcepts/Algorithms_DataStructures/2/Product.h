#ifndef PRODUCT_H
#define PRODUCT_H
 
#include <string>
 
class Product {
public:
    Product();
    Product(int id, const std::string& name, const std::string& cat);
 
    int getProductId() const;
    std::string getProductName() const;
    std::string getCategory() const;
 
    void display() const;
 
private:
    int productId;
    std::string productName;
    std::string category;
};
 
#endif