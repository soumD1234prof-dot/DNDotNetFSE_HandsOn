#ifndef LOGGER_H
#define LOGGER_H
 
#include <string>
 
class Logger {
public:

    static Logger& getInstance();
 
    Logger(const Logger&) = delete;
    Logger& operator=(const Logger&) = delete;
    void log(const std::string& message);
 
private:

    Logger();
    ~Logger();
    int logCount;
};
 
#endif