namespace FactoryMethodPattern;
 
public abstract class DocumentFactory
{
    public abstract IDocument CreateDocument();
 
    public IDocument ProcessNewDocument()
    {
        IDocument doc = CreateDocument();
        Console.WriteLine($"Factory produced a {doc.Type} document.");
        doc.Open();
        doc.Save();
        return doc;
    }
}
 
public class WordDocumentFactory : DocumentFactory
{
    public override IDocument CreateDocument() => new WordDocument();
}
 
public class PdfDocumentFactory : DocumentFactory
{
    public override IDocument CreateDocument() => new PdfDocument();
}
 
public class ExcelDocumentFactory : DocumentFactory
{
    public override IDocument CreateDocument() => new ExcelDocument();
}