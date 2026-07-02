#ifndef DOC_H
#define DOC_H
 
#include <string>
 
class Document {
public:
    virtual ~Document() = default;
    virtual void open() = 0;
    virtual void save() = 0;
    virtual std::string getType() const = 0;
};
 
class WordDocument : public Document {
public:
    void open() override;
    void save() override;
    std::string getType() const override;
};
 
class PdfDocument : public Document {
public:
    void open() override;
    void save() override;
    std::string getType() const override;
};
 
class ExcelDocument : public Document {
public:
    void open() override;
    void save() override;
    std::string getType() const override;
};
 
#endif