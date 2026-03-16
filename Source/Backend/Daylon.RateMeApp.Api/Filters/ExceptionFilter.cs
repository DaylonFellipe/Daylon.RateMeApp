using Daylon.RateMeApp.Communication.Responses.Error;
using Daylon.RateMeApp.Exceptions;
using Daylon.RateMeApp.Exceptions.ExceptionBases;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace Daylon.RateMeApp.Api.Filters
{
    public class ExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            switch (context.Exception)
            {
                case ErrorOnValidationException ex:
                    HandleValidationException(context, ex);
                    break;

                case RateMeAppException ex:
                    HandleRateMeAppException(context, ex);
                    break;

                default:
                    HandleUnknowException(context);
                    break;
            }
        } 
        
        private void HandleValidationException(ExceptionContext context, ErrorOnValidationException ex)
        {
            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            context.Result = new BadRequestObjectResult(new ResponseErrorJson(ex.ErrorsMessages));
            context.ExceptionHandled = true;
        }

        private void HandleRateMeAppException(ExceptionContext context, RateMeAppException ex)
        {
            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            context.Result = new BadRequestObjectResult(new ResponseErrorJson(ex.Message));
            context.ExceptionHandled = true;
        }

        private void HandleUnknowException(ExceptionContext context)
        {
            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            context.Result = new ObjectResult(new ResponseErrorJson(ResourceMessagesException.UNKNOW_ERROR));
            context.ExceptionHandled = true;
        }
    }
}