using System;
using System.Collections.Generic;
using System.Net;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
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
                //logging and handling errors according to business rules

                if (ex?.Error != null)
                {
                    Console.WriteLine($"Error: {ex.Error.Message}");

                    if (ex.Error is DbUpdateException exception && exception.InnerException != null)
                    {
                        var errorMessage = "duplicate key value violates unique constraint";
                        if (exception.InnerException.Message.Contains(errorMessage))
                        {
                            context.Response.ContentType = "application/json";
                            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                            await context.Response.WriteAsync(JsonConvert.SerializeObject(errorMessage));

                        }
                    }
                }

                

            });
        }
    }
}