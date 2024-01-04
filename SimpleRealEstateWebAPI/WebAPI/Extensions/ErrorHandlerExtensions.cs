﻿using Application.Common.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using System.Net;
using System.Text.Json;

namespace WebAPI.Extensions
{
    public static class ErrorHandlerExtensions
    {
        public static void UseErrorHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature == null) return;

                    context.Response.Headers.Add("Access-Control-Allow-Origin", "*");
                    context.Response.ContentType = "application/json";

                    var errorDetails = new string[] { };

                    switch (contextFeature.Error)
                    {
                        case BadRequestException:
                            {
                                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                                var exception = (BadRequestException)contextFeature.Error;
                                errorDetails = exception.Errors;
                                break;
                            }

                        case UnauthorizedAccessException:
                            {
                                context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                                var exception = (UnauthorizedAccessException)contextFeature.Error;
                                break;
                            }


                        case OperationCanceledException:
                            {
                                context.Response.StatusCode = (int)HttpStatusCode.ServiceUnavailable;
                                errorDetails = null;
                                break;
                            }

                        case NotFoundException:
                            {
                                context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                                errorDetails = null;
                                break;
                            }

                        case AlreadyExistException:
                            {
                                context.Response.StatusCode = 403;
                                errorDetails = null;
                                break;
                            }

                        default:
                            {
                                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                                errorDetails = null;
                                break;
                            }
                    }

                    var errorResponse = new
                    {
                        statusCode = context.Response.StatusCode,
                        message = contextFeature.Error.GetBaseException().Message,
                        errorDetails = errorDetails
                    };

                    await context.Response.WriteAsync(JsonSerializer.Serialize(errorResponse));
                });
            });
        }
    }
}