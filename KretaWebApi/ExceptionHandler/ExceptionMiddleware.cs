﻿using Kreta.ExceptionHandler;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ServiceKretaLogger;
using System.Net;

namespace KretaWebApi.ExceptionHandler
{
    // https://code-maze.com/global-error-handling-aspnetcore/
    // https://www.puresourcecode.com/dotnet/net6/handling-exceptions-globally-with-net6/

    public class ExceptionMiddleware
    {
        private readonly RequestDelegate next;
        private readonly ILoggerManager logger;
        private readonly bool isDev;

        public ExceptionMiddleware(RequestDelegate next, ILoggerManager logger)
        {
            this.next = next;
            this.logger = logger;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await next(httpContext);
            }
            catch (Exception ex)
            {
                logger.LogError($"Valami hiba történt: {ex}");
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext httpContext, Exception exception)
        {
            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            var message = exception switch
            {
                AccessViolationException => "Access violation error",
                _ => "Internal server error",

            };

            await httpContext.Response.WriteAsync(
                new ErrorDetails()
                {
                    StatusCode = httpContext.Response.StatusCode,
                    Message = message,
                }.ToString()
           );
        }        
    }
}
