#ifndef DOC_FACTORY_H
#define DOC_FACTORY_H
 
#include "Doc.h"
#include <memory>
 
class DocumentFactory {
public:
    virtual ~DocumentFactory() = default;
    virtual std::unique_ptr<Document> createDocument() = 0;
    std::unique_ptr<Document> processNewDocument();
};
 
class WordDocumentFactory : public DocumentFactory {
public:
    std::unique_ptr<Document> createDocument() override;
};
 
class PdfDocumentFactory : public DocumentFactory {
public:
    std::unique_ptr<Document> createDocument() override;
};
 
class ExcelDocumentFactory : public DocumentFactory {
public:
    std::unique_ptr<Document> createDocument() override;
};
 
#endif