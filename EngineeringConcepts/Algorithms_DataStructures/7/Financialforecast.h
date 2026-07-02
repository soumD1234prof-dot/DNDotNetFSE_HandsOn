#ifndef FINANCIAL_FORECAST_H
#define FINANCIAL_FORECAST_H
 
#include <vector>
 
double calcFV(double presentValue, const std::vector<double>& growthRates, int year);
 
double naiveBestFV(double presentValue, const std::vector<std::vector<double>>& scenarios);
 
double optimizedBestFV(double presentValue, const std::vector<std::vector<double>>& scenarios);
 
#endif