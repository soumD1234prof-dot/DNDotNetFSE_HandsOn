#include "Doc.h"
#include <iostream>
 
void WordDocument::open() {
    std::cout << "Opening a Word document (.docx)..." << std::endl;
}
 
void WordDocument::save() {
    std::cout << "Saving Word document..." << std::endl;
}
 
std::string WordDocument::getType() const {
    return "Word";
}
 
void PdfDocument::open() {
    std::cout << "Opening a PDF document (.pdf)..." << std::endl;
}
 
void PdfDocument::save() {
    std::cout << "Saving PDF document..." << std::endl;
}
 
std::string PdfDocument::getType() const {
    return "PDF";
}
 
void ExcelDocument::open() {
    std::cout << "Opening an Excel document (.xlsx)..." << std::endl;
}
 
void ExcelDocument::save() {
    std::cout << "Saving Excel document..." << std::endl;
}
 
std::string ExcelDocument::getType() const {
    return "Excel";
}