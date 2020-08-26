using Elk.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using System;
using System.Net;

namespace GolPooch.Api
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false)]
    public class AuthorizeFilter : ActionFilterAttribute
    {
        private readonly IConfiguration _configuration;
        public AuthorizeFilter(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            return;
            if (!filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                filterContext.HttpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                filterContext.Result = new JsonResult(new Response<int>
                {
                    Message = "UnAuthorized Access. Invalid Token To Access Api.",
                    Result = (int)HttpStatusCode.Unauthorized,
                    IsSuccessful = false
                });
                return;
            }

            if (!(filterContext.HttpContext.Request.Headers["apiKey"].Count > 0))
            {
                filterContext.HttpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                filterContext.Result = new JsonResult(new Response<int>
                {
                    Message = "UnAuthorized Access. Invalid Token To Access Api.",
                    Result = (int)HttpStatusCode.Unauthorized,
                    IsSuccessful = false
                });
                return;
            }
            var key = filterContext.HttpContext.Request.Headers["apiKey"][0];

            if (_configuration.GetSection("Api-Key").Value == key)
                return;
            filterContext.HttpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
            filterContext.Result = new JsonResult(new Response<int>
            {
                IsSuccessful = false,
                Result = (int)HttpStatusCode.Unauthorized,
                Message = "UnAuthorized Access. Ip Not Valid."
            });
        }
    }
}
