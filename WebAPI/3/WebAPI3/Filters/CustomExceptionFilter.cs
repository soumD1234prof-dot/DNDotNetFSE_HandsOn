using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebAPI3.Filters
{
    public class CustomExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            var exceptionDetail = context.Exception.ToString();

            //exception detail
            var logPath = Path.Combine(AppContext.BaseDirectory, "error_log.txt");
            File.AppendAllText(logPath, $"{DateTime.Now}: {exceptionDetail}{Environment.NewLine}{Environment.NewLine}");

            context.Result = new ObjectResult(new { message = "An unexpected error occurred!!!", detail = context.Exception.Message })
            {
                StatusCode = StatusCodes.Status500InternalServerError
            };

            context.ExceptionHandled = true;
        }
    }
}