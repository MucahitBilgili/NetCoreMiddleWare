using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreMiddleWare.MiddleWare
{
    public class LoggingMiddleware
    {
        readonly RequestDelegate _next;
        public LoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            finally
            {
                string logText = $"{context.Request?.Method} {context.Request?.Path.Value} => {context.Response?.StatusCode}{Environment.NewLine}";
                File.AppendAllText("log.txt", logText);
            }
        }
    }
}
