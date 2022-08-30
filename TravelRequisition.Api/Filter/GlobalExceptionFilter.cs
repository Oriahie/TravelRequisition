using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelRequisition.Core.Utilities;
using TravelRequisition.Infrastructure.Models;

namespace TravelRequisition.Api.Filter
{
    public class GlobalExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            var content = GetStatusCode<object>(context.Exception);
            HttpResponse response = context.HttpContext.Response;
            response.ContentType = "application/json";

            context.Result = new JsonResult(content);
        }
        private static Response<T> GetStatusCode<T>(Exception exception)
        {
            switch (exception)
            {
                case Exception bex:
                    return (new Response<T>
                    {
                        Message = bex.GetInnerMessage(),
                        Succeeded = false
                    });
                default:
                    var model = new Response<T>
                    {
                        Message = "An unexpected error occured. " +
                                 $"Please try again or contact administrator if issue persist",
                        Succeeded = false
                    };
                    return (model);
            }
        }

    }
}
