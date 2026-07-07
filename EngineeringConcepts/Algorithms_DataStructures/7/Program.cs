using System.Diagnostics;
 
namespace FinancialForecasting;
 
public static class Program
{
    public static void Main(string[] args)
    {
        double presentValue = 10000.0;
        var historicalGrowthRates = new List<double> { 0.05, 0.07, 0.04, 0.06, 0.03 };
 
        double simpleForecast = FinancialForecast.CalculateFV(
            presentValue, historicalGrowthRates, historicalGrowthRates.Count);
 
        Console.WriteLine("\nSimple recursive forecast");
        Console.WriteLine($"Present value: ${presentValue:F2}");
        Console.WriteLine($"Years projected: {historicalGrowthRates.Count}");
        Console.WriteLine($"Future value: ${simpleForecast:F2}");
 
        Console.WriteLine("\nBest-case scenario forecast (multiple possible growth rates per year)");
 
        int years = 24;
        var scenarios = new List<List<double>>();
        for (int i = 0; i < years; i++)
        {
            scenarios.Add(new List<double> { 0.02, 0.09 });
        }
 
        var stopwatchNaive = Stopwatch.StartNew();
        double naiveResult = FinancialForecast.NaiveBestFV(presentValue, scenarios);
        stopwatchNaive.Stop();
 
        var stopwatchOptimized = Stopwatch.StartNew();
        double optimizedResult = FinancialForecast.OptimizedBestFV(presentValue, scenarios);
        stopwatchOptimized.Stop();
 
        Console.WriteLine($"Years: {years}, scenarios per year: 2");
        Console.WriteLine($"Naive recursion result:     ${naiveResult:F2}  ({stopwatchNaive.Elapsed.TotalMilliseconds:F2} ms)");
        Console.WriteLine($"Memoized recursion result:  ${optimizedResult:F2}  ({stopwatchOptimized.Elapsed.TotalMilliseconds:F2} ms)");
    }
}