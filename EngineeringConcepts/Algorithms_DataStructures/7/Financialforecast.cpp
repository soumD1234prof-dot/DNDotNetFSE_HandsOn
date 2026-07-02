#include "FinancialForecast.h"
#include <algorithm>
 
double calcFV(double presentValue, const std::vector<double>& growthRates, int year) {
    if (year == 0) {
        return presentValue;
    }
    double previousValue = calcFV(presentValue, growthRates, year - 1);
    double rate = growthRates[year - 1];
    return previousValue * (1.0 + rate);
}
 
static double naiveBestMultiplier(const std::vector<std::vector<double>>& scenarios, int year) {
    if (year == static_cast<int>(scenarios.size())) {
        return 1.0;
    }
    double best = -1.0;
    for (double rate : scenarios[year]) {
        double candidate = (1.0 + rate) * naiveBestMultiplier(scenarios, year + 1);
        best = std::max(best, candidate);
    }
    return best;
}
 
double naiveBestFV(double presentValue, const std::vector<std::vector<double>>& scenarios) {
    return presentValue * naiveBestMultiplier(scenarios, 0);
}
 
static double memoBestMultiplier(const std::vector<std::vector<double>>& scenarios, int year,
                                  std::vector<double>& memo) {
    if (year == static_cast<int>(scenarios.size())) {
        return 1.0;
    }
    if (memo[year] >= 0.0) {
        return memo[year];
    }
    double best = -1.0;
    for (double rate : scenarios[year]) {
        double candidate = (1.0 + rate) * memoBestMultiplier(scenarios, year + 1, memo);
        best = std::max(best, candidate);
    }
    memo[year] = best;
    return best;
}
 
double optimizedBestFV(double presentValue, const std::vector<std::vector<double>>& scenarios) {
    std::vector<double> memo(scenarios.size(), -1.0);
    return presentValue * memoBestMultiplier(scenarios, 0, memo);
}