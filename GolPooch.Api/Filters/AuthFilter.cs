using System;
using Elk.Core;
using Elk.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;

namespace GolPooch.Api
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    public class AuthFilter : ActionFilterAttribute, IAsyncActionFilter
    {
        public override async Task OnActionExecutionAsync(ActionExecutingContext filterContext, ActionExecutionDelegate next)
        {
            try
            {
                var ip = ClientInfo.GetIP(filterContext.HttpContext);
                if (filterContext.HttpContext.Request.Headers["Token"].Count > 0)
                {
                    #region Existing Token
                    if (Guid.TryParse(filterContext.HttpContext.Request.Headers["Token"][0], out Guid token))
                    {
                        var configuration = (filterContext.HttpContext.RequestServices.GetService(typeof(IConfiguration)) as IConfiguration);
                        if (token != Guid.Parse(configuration.GetSection("CustomSettings")["AuthenticateToken"]))
                        {
                            FileLoger.Info($"Invalid Token To Access Api !" + Environment.NewLine +
                                $"IP:{ip}" + Environment.NewLine +
                                $"Token:{filterContext.HttpContext.Request.Headers["Token"][0]}");

                            filterContext.HttpContext.Response.StatusCode = 401;
                            filterContext.Result = new JsonResult(new Response<object>
                            {
                                ResultCode = 401,
                                IsSuccessful = false,
                                Message = "UnAuthorized Access. Invalid Token To Access Api."
                            });
                        }
                    }
                    else
                    {
                        FileLoger.Info($"Invalid Token Type To Access Api  !" + Environment.NewLine +
                                $"IP:{ip}" + Environment.NewLine +
                                $"Token:{filterContext.HttpContext.Request.Headers["Token"][0]}");

                        filterContext.HttpContext.Response.StatusCode = 401;
                        filterContext.Result = new JsonResult(new Response<object>
                        {
                            ResultCode = 401,
                            IsSuccessful = false,
                            Message = "UnAuthorized Access. Invalid Token Type To Access Api !"
                        });
                    }
                    #endregion
                }
                else
                {
                    #region Not Existing Token
                    FileLoger.Info($"UnAuthorized Access To Api ! IP:{ip}");

                    filterContext.HttpContext.Response.StatusCode = 403;
                    filterContext.Result = new JsonResult(new Response<object>
                    {
                        ResultCode = 403,
                        IsSuccessful = false,
                        Message = "UnAuthorized Access. Token Not Sent."
                    });
                    #endregion
                }

                await base.OnActionExecutionAsync(filterContext, next);
            }
            catch (Exception e)
            {
                FileLoger.Error(e);
                filterContext.HttpContext.Response.StatusCode = 500;
                filterContext.Result = new JsonResult(new Response<object>
                {
                    ResultCode = 500,
                    IsSuccessful = false,
                    Message = "Internall Error."
                });

                await base.OnActionExecutionAsync(filterContext, next);
            }
        }
    }
}