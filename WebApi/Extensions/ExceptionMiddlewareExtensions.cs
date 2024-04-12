﻿using Entities.ErrorModel;
using Microsoft.AspNetCore.Diagnostics;
using Services.Contracts;
using System.Net;
using System.Xml.Serialization;

namespace WebApi.Extensions
{
    public static class ExceptionMiddlewareExtensions
    {
        public static void ConfigureExceptionHandler(this WebApplication app,
            ILoggerService logger)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "application/json";

                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();

                    if (contextFeature is not null) 
                    {
                        logger.LogError($"Something went wrong : {contextFeature.Error}");
                        await context.Response.WriteAsync(new ErrorDetails()
                        {
                            Status = context.Response.StatusCode,
                            Message = "Internal server error"
                        }.ToString());
                    }
                });
            });


        }
    }
}
