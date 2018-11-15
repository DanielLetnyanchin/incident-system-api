using IncidentSystem.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace IncidentSystem.API.ActionFilters
{
    public class GlobalExceptionFilter : ExceptionFilterAttribute
    {
        private readonly ILoggerWrapper _logger;

        public GlobalExceptionFilter(ILoggerWrapper logger)
        {
            _logger = logger;
        }

        public override void OnException(ExceptionContext context)
        {
            _logger.Error(context.HttpContext.TraceIdentifier,context.Exception.Message, context.Exception.StackTrace);

            context.Result = new JsonResult(new
            {
                StatusCode = 500,
                Message = "Internal Server Error from the custom middleware."
            });
        }
    }
}
