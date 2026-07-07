using System;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace EmployeeWebApiDemo.Filters
{
    // Custom result type, mirroring the "ExceptionResult" the task refers to
    public class ExceptionResult : ObjectResult
    {
        public ExceptionResult(object value) : base(value)
        {
            StatusCode = StatusCodes.Status500InternalServerError;
        }
    }

    public class CustomExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            string exceptionDetail = context.Exception.ToString();
            string logDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Logs");
            string logPath = Path.Combine(logDirectory, "exception_log.txt");

            Directory.CreateDirectory(logDirectory);
            File.AppendAllText(logPath, $"{DateTime.Now}: {exceptionDetail}{Environment.NewLine}{Environment.NewLine}");

            context.Result = new ExceptionResult(new
            {
                Message = context.Exception.Message,
                Detail = "An unexpected error occurred. Please contact support."
            });

            context.ExceptionHandled = true;
        }
    }
}