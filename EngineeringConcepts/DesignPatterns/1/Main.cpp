#include "Logger.h"
#include <iostream>
 
void DoWork() {
    Logger& logger = Logger::getInstance();
    logger.log("Message from DoWork()");
}
 
int main() {
    Logger& logger1 = Logger::getInstance();
    logger1.log("First message from main()");
 
    Logger& logger2 = Logger::getInstance();
    logger2.log("Second message from main()");
 
    DoWork();
 
    if (&logger1 == &logger2) {
        std::cout << "logger1 and logger2 point to the same instance." << std::endl;
    } else {
        std::cout << "logger1 and logger2 point to different instances!" << std::endl;
    }
 
    std::cout << "Address of logger1: " << &logger1 << std::endl;
    std::cout << "Address of logger2: " << &logger2 << std::endl;
 
    return 0;
}