#include "Docfactory.h"
#include <iostream>
#include <memory>
#include <vector>
 
void createAndUse(DocumentFactory& factory) {
    std::unique_ptr<Document> doc = factory.createDocument();
    doc->open();
    doc->save();
    std::cout << "---" << std::endl;
}
 
int main() {
    WordDocumentFactory wordFactory;
    PdfDocumentFactory pdfFactory;
    ExcelDocumentFactory excelFactory;
 
    std::cout << "Creating documents directly through their factories:" << std::endl;
    createAndUse(wordFactory);
    createAndUse(pdfFactory);
    createAndUse(excelFactory);
 
    std::cout << "Creating documents through the shared processNewDocument() workflow:" << std::endl;
    wordFactory.processNewDocument();
    pdfFactory.processNewDocument();
    excelFactory.processNewDocument();
 
    std::cout << "Choosing a factory at runtime through a common base pointer:" << std::endl;
    std::vector<std::unique_ptr<DocumentFactory>> factories;
    factories.push_back(std::make_unique<WordDocumentFactory>());
    factories.push_back(std::make_unique<PdfDocumentFactory>());
    factories.push_back(std::make_unique<ExcelDocumentFactory>());
 
    for (auto& factory : factories) {
        std::unique_ptr<Document> doc = factory->createDocument();
        std::cout << "Created: " << doc->getType() << std::endl;
    }
 
    return 0;
}