using DevFreela.Infrastructure.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Net;

namespace DevFreela.Api.Extensions
{
    public class CustomExceptionFilter : IExceptionFilter
    {
        private readonly ILogger _logger;

        public CustomExceptionFilter(ILogger<CustomExceptionFilter> logger)
        {
            _logger = logger;
        }

        public void OnException(ExceptionContext context)
        {
            HttpStatusCode status = HttpStatusCode.InternalServerError;

            var exception = context.Exception;

            HttpResponse response = context.HttpContext.Response;

            if (exception.GetType() == typeof(ArgumentException))
            {
                status = HttpStatusCode.BadRequest;
            }
            else if (exception.GetType() == typeof(CustomException))
            {
                status = HttpStatusCode.BadRequest;
                CustomException customException = (CustomException)exception;

                _logger.LogWarning($"ExceptionMessage: {customException.ExceptionMessage} \n " +
                    $"ExceptionFix: {customException.ExceptionFix} \n " +
                    $"ExceptionReason {customException.ExceptionReason}");
            }

            response.StatusCode = (int)status;

            if (response.HttpContext.RequestAborted.IsCancellationRequested)
            {
                response.StatusCode = 499;
            }

            response.ContentType = "application/json";
            context.Result = new JsonResult(exception);
        }
    }
}