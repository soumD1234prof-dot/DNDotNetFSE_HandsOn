namespace SingletonPatternExample;
 
public static class Program
{
    private static void DoWork()
    {
        Logger logger = Logger.Instance;
        logger.Log("Message from DoWork()");
    }
 
    public static void Main(string[] args)
    {
        Logger logger1 = Logger.Instance;
        logger1.Log("First message from Main()");
 
        Logger logger2 = Logger.Instance;
        logger2.Log("Second message from Main()");
 
        DoWork();
 
        if (ReferenceEquals(logger1, logger2))
        {
            Console.WriteLine("logger1 and logger2 refer to the SAME instance.");
        }
        else
        {
            Console.WriteLine("logger1 and logger2 refer to DIFFERENT instances!");
        }
 
        Console.WriteLine($"Hash code of logger1: {logger1.GetHashCode()}");
        Console.WriteLine($"Hash code of logger2: {logger2.GetHashCode()}");
    }
}