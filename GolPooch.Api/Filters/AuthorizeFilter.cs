using System;
using Elk.Core;
using Elk.Http;
using System.Linq;
using GolPooch.Domain.Entity;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Controllers;

namespace GolPooch.Api
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false)]
    public class AuthorizeFilter : ActionFilterAttribute, IAsyncActionFilter
    {
        public override async Task OnActionExecutionAsync(ActionExecutingContext filterContext, ActionExecutionDelegate next)
        {
            try
            {
                var actionDescriptor = filterContext.ActionDescriptor as ControllerActionDescriptor;
                if (actionDescriptor != null)
                {
                    var actionAttributes = actionDescriptor.MethodInfo.GetCustomAttributes(inherit: true);
                    if (actionAttributes.Any(a => a.GetType().Equals(typeof(AllowAnonymousAttribute))))
                        await base.OnActionExecutionAsync(filterContext, next);
                }

                var ip = ClientInfo.GetIP(filterContext.HttpContext);
                if (filterContext.HttpContext.Request.Headers["UserId"].Count > 0)
                {
                    #region Existing Header Parameter
                    var userId = int.Parse(filterContext.HttpContext.Request.Headers["UserId"][0]);
                    if (userId > 0)
                    {
                        var usreRepo = (IGenericRepo<User>)filterContext.HttpContext.RequestServices.GetService(typeof(IGenericRepo<User>));
                        var user = await usreRepo.FindAsync(userId);
                        if (user != null)
                        {
                            if (filterContext.ActionArguments.ContainsKey("User"))
                                filterContext.ActionArguments["User"] = user;

                            //await base.OnActionExecutionAsync(filterContext, next);
                        }
                        else
                        {
                            FileLoger.Info($"Invalid Token Content To Access Api !" + Environment.NewLine +
                                    $"IP:{ip}" + Environment.NewLine +
                                    $"UserId:{filterContext.HttpContext.Request.Headers["UserId"][0]}");

                            filterContext.HttpContext.Response.StatusCode = 401;
                            filterContext.Result = new JsonResult(new Response<object>
                            {
                                ResultCode = 401,
                                IsSuccessful = false,
                                Message = "UnAuthorized Access. Invalid Token Content To Access Api !"
                            });
                        }
                    }
                    else
                    {
                        FileLoger.Info($"Invalid Token To Access Api !" + Environment.NewLine +
                                $"IP:{ip}" + Environment.NewLine +
                                $"UserId:{filterContext.HttpContext.Request.Headers["UserId"][0]}");

                        filterContext.HttpContext.Response.StatusCode = 403;
                        filterContext.Result = new JsonResult(new Response<object>
                        {
                            ResultCode = 403,
                            IsSuccessful = false,
                            Message = "UnAuthorized Access. Invalid Token To Access Api !"
                        });
                    }
                    #endregion
                }
                else
                {
                    #region Not Existing Header Parameter
                    FileLoger.Info($"UnAuthorized Access To Api ! IP:{ip}");

                    filterContext.HttpContext.Response.StatusCode = 403;
                    filterContext.Result = new JsonResult(new Response<object>
                    {
                        ResultCode = 403,
                        IsSuccessful = false,
                        Message = "UnAuthorized Access To Api ! Token Not Sent."
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
                    Message = "Internall Error." + Environment.NewLine + e.Message
                });

                await base.OnActionExecutionAsync(filterContext, next);
            }
        }
    }
}