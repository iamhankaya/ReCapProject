using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Net;

    
    using System.Threading.Tasks;
    using FluentValidation;
    using FluentValidation.Results;
    using Microsoft.AspNetCore.Http;
    using System.Text.Json;

    namespace Core.Extensions
    {
        public class ExceptionMiddleware
        {
            private RequestDelegate _next;

            public ExceptionMiddleware(RequestDelegate next)
            {
                _next = next;
            }

            public async Task InvokeAsync(HttpContext httpContext)
            {
                try
                {
                    await _next(httpContext);
                }
                catch (Exception e)
                {
                    await HandleExceptionAsync(httpContext, e);
                }
            }

            private Task HandleExceptionAsync(HttpContext httpContext, Exception e)
            {
                httpContext.Response.ContentType = "application/json";
                httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                string message = "Internal Server Error";
                IEnumerable<ValidationFailure> errors;
                if (e.GetType() == typeof(ValidationException))
                {
                    message = e.Message;
                    errors = ((ValidationException)e).Errors;
                    httpContext.Response.StatusCode = 400;

                    var validationErrorDetails = new ValidationErrorDetails
                    {
                        StatusCode = 400,
                        Message = message,
                        Errors = errors
                    };

                    // JSON olarak döndür.
                    return httpContext.Response.WriteAsync(JsonSerializer.Serialize(validationErrorDetails));
                }

                return httpContext.Response.WriteAsync(new ErrorDetails
                {
                    StatusCode = httpContext.Response.StatusCode,
                    Message = message
                }.ToString());
            }
        }
    }
}
