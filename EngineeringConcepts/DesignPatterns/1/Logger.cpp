#include "Logger.h"
#include <iostream>
 
Logger::Logger() : logCount(0) {
    std::cout << "Logger instance created at address: " << this << std::endl;
}
 
Logger::~Logger() {
    std::cout << "Logger instance destroyed." << std::endl;
}
 
Logger& Logger::getInstance() {
    static Logger instance;
    return instance;
}
 
void Logger::log(const std::string& message) {
    ++logCount;
    std::cout << "[LOG #" << logCount << "] " << message << std::endl;
}