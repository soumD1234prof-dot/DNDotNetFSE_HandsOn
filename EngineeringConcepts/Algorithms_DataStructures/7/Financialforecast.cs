namespace FinancialForecasting;
 
public static class FinancialForecast
{
    public static double CalculateFV(double presentValue, List<double> growthRates, int year)
    {
        if (year == 0)
        {
            return presentValue;
        }
        double previousValue = CalculateFV(presentValue, growthRates, year - 1);
        double rate = growthRates[year - 1];
        return previousValue * (1.0 + rate);
    }
 
    private static double NaiveBestMultiplier(List<List<double>> scenarios, int year)
    {
        if (year == scenarios.Count)
        {
            return 1.0;
        }
        double best = -1.0;
        foreach (double rate in scenarios[year])
        {
            double candidate = (1.0 + rate) * NaiveBestMultiplier(scenarios, year + 1);
            best = Math.Max(best, candidate);
        }
        return best;
    }
 
    public static double NaiveBestFV(double presentValue, List<List<double>> scenarios)
    {
        return presentValue * NaiveBestMultiplier(scenarios, 0);
    }
 
    private static double MemoBestMultiplier(List<List<double>> scenarios, int year, double[] memo)
    {
        if (year == scenarios.Count)
        {
            return 1.0;
        }
        if (memo[year] >= 0.0)
        {
            return memo[year];
        }
        double best = -1.0;
        foreach (double rate in scenarios[year])
        {
            double candidate = (1.0 + rate) * MemoBestMultiplier(scenarios, year + 1, memo);
            best = Math.Max(best, candidate);
        }
        memo[year] = best;
        return best;
    }
 
    public static double OptimizedBestFV(double presentValue, List<List<double>> scenarios)
    {
        double[] memo = new double[scenarios.Count];
        Array.Fill(memo, -1.0);
        return presentValue * MemoBestMultiplier(scenarios, 0, memo);
    }
}