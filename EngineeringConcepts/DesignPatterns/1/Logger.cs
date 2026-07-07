namespace SingletonPatternExample;
 
public sealed class Logger
{
    private static readonly Lazy<Logger> lazyInstance = new Lazy<Logger>(() => new Logger());
 
    private int logCount;
 
    private Logger()
    {
        logCount = 0;
        Console.WriteLine($"Logger instance created with hash code: {GetHashCode()}");
    }
 
    public static Logger Instance => lazyInstance.Value;
 
    public void Log(string message)
    {
        logCount++;
        Console.WriteLine($"[LOG #{logCount}] {message}");
    }
}