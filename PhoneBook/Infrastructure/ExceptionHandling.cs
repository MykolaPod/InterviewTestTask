using System;
using System.Collections.Generic;
using System.Net;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

namespace Infrastructure
{
    public static class ExceptionHandling
    {
        public static void ApplyExceptionHandlingOptions(this IApplicationBuilder app)
        {
            app.Run(async context =>
            {
                var ex = context.Features.Get<IExceptionHandlerFeature>();

                if (ex?.Error != null)
                {
                    Console.WriteLine($"Error: {ex.Error.Message}");
                }

            });
        }
    }
}