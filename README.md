# NetCoreMiddleWare
  ### LoggingMiddleware.cs
 ```cs 
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
 ```
 ### LoggingMiddlewareExtension.cs
 ```cs 
using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreMiddleWare.MiddleWare
{
    public static class LoggingMiddlewareExtension
    {
        public static IApplicationBuilder UseLogging(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<LoggingMiddleware>();
        }
    }
}
  ```
  ### Startup.cs
 ```cs 
 public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
           //......
            app.UseLogging();
        }
  ```
