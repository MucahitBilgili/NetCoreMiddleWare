using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreMiddleWare.MiddleWare
{
    public static class MiddlewareExtension
    {
        public static IApplicationBuilder UseHeaderCheckMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<HeaderCheckMiddleware>();
        }
    }
}
