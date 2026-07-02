#include "Docfactory.h"
#include <iostream>
 
std::unique_ptr<Document> DocumentFactory::processNewDocument() {
    std::unique_ptr<Document> doc = createDocument();
    std::cout << "Factory produced a " << doc->getType() << " document!" << std::endl;
    doc->open();
    doc->save();
    return doc;
}
 
std::unique_ptr<Document> WordDocumentFactory::createDocument() {
    return std::make_unique<WordDocument>();
}
 
std::unique_ptr<Document> PdfDocumentFactory::createDocument() {
    return std::make_unique<PdfDocument>();
}
 
std::unique_ptr<Document> ExcelDocumentFactory::createDocument() {
    return std::make_unique<ExcelDocument>();
}