#include "FinancialForecast.h"
#include <iostream>
#include <vector>
#include <chrono>
#include <iomanip>
 
int main() {
    double presentValue = 10000.0;
    std::vector<double> historicalGrowthRates = {0.05, 0.07, 0.04, 0.06, 0.03};
 
    double simpleForecast = calcFV(presentValue, historicalGrowthRates, static_cast<int>(historicalGrowthRates.size()));
 
    std::cout << std::fixed << std::setprecision(2);
    std::cout << "\nSimple recursive forecast" << std::endl;
    std::cout << "\nPresent value: $" << presentValue << std::endl;
    std::cout << "Years projected: " << historicalGrowthRates.size() << std::endl;
    std::cout << "Future value: $" << simpleForecast << std::endl;
 
    std::cout << "\nBest-case scenario forecast (multiple possible growth rates per year)" << std::endl;
 
    int years = 24;
    std::vector<std::vector<double>> scenarios(years, std::vector<double>{0.02, 0.09});
 
    auto startNaive = std::chrono::steady_clock::now();
    double naiveResult = naiveBestFV(presentValue, scenarios);
    auto endNaive = std::chrono::steady_clock::now();
    double naiveMs = std::chrono::duration<double, std::milli>(endNaive - startNaive).count();
 
    auto startOptimized = std::chrono::steady_clock::now();
    double optimizedResult = optimizedBestFV(presentValue, scenarios);
    auto endOptimized = std::chrono::steady_clock::now();
    double optimizedMs = std::chrono::duration<double, std::milli>(endOptimized - startOptimized).count();
 
    std::cout << "\nYears: " << years << ", scenarios per year: 2" << std::endl;
    std::cout << "\nNaive recursion result:     $" << naiveResult
              << "  (" << naiveMs << " ms)" << std::endl;
    std::cout << "Memoized recursion result:  $" << optimizedResult
              << "  (" << optimizedMs << " ms)" << std::endl;
 
    return 0;
}