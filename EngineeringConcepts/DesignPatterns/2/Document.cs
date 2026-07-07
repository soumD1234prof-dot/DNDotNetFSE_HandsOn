namespace FactoryMethodPattern;
 
public interface IDocument
{
    void Open();
    void Save();
    string Type { get; }
}
 
public class WordDocument : IDocument
{
    public string Type => "Word";
 
    public void Open() => Console.WriteLine("Opening a Word document (.docx)...");
 
    public void Save() => Console.WriteLine("Saving Word document...");
}
 
public class PdfDocument : IDocument
{
    public string Type => "PDF";
 
    public void Open() => Console.WriteLine("Opening a PDF document (.pdf)...");
 
    public void Save() => Console.WriteLine("Saving PDF document...");
}
 
public class ExcelDocument : IDocument
{
    public string Type => "Excel";
 
    public void Open() => Console.WriteLine("Opening an Excel document (.xlsx)...");
 
    public void Save() => Console.WriteLine("Saving Excel document...");
}