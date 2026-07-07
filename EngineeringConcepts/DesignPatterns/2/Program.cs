namespace FactoryMethodPattern;
 
public static class Program
{
    private static void CreateAndUse(DocumentFactory factory)
    {
        IDocument doc = factory.CreateDocument();
        doc.Open();
        doc.Save();
        Console.WriteLine("---");
    }
 
    public static void Main(string[] args)
    {
        var wordFactory = new WordDocumentFactory();
        var pdfFactory = new PdfDocumentFactory();
        var excelFactory = new ExcelDocumentFactory();
 
        Console.WriteLine("\nCreating documents directly through their factories:");
        CreateAndUse(wordFactory);
        CreateAndUse(pdfFactory);
        CreateAndUse(excelFactory);
 
        Console.WriteLine("Creating documents through the shared ProcessNewDocument() workflow:");
        wordFactory.ProcessNewDocument();
        pdfFactory.ProcessNewDocument();
        excelFactory.ProcessNewDocument();
 
        Console.WriteLine("Choosing a factory at runtime through a common base type:");
        List<DocumentFactory> factories = new List<DocumentFactory>
        {
            new WordDocumentFactory(),
            new PdfDocumentFactory(),
            new ExcelDocumentFactory()
        };
 
        foreach (DocumentFactory factory in factories)
        {
            IDocument doc = factory.CreateDocument();
            Console.WriteLine($"Created: {doc.Type}");
        }
    }
}