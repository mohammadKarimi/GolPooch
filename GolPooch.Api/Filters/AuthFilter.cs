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
        private IConfiguration _configuration;


        public override async Task OnActionExecutionAsync(ActionExecutingContext filterContext, ActionExecutionDelegate next)
        {
            try
            {
                var ip = ClientInfo.GetIP(filterContext.HttpContext);
                _configuration = (filterContext.HttpContext.RequestServices.GetService(typeof(IConfiguration)) as IConfiguration);
                if (filterContext.HttpContext.Request.Headers["Token"].Count > 0)
                {
                    #region Existing Token
                    if (Guid.TryParse(filterContext.HttpContext.Request.Headers["Token"][0], out Guid token))
                    {
                        if (token != Guid.Parse(_configuration.GetSection("CustomSettings")["AuthenticateToken"]))
                        {
                            FileLoger.Info($"Invalid Token To Access Api  !" + Environment.NewLine +
                                $"IP:{ip}" + Environment.NewLine +
                                $"Token:{filterContext.HttpContext.Request.Headers["Token"][0]}");

                            filterContext.HttpContext.Response.StatusCode = 200;
                            filterContext.Result = new JsonResult(new
                            {
                                Message = "UnAuthorized Access. Invalid Token To Access Api.",
                                Result = 200,
                                IsSuccessful = false
                            });
                        }
                    }
                    else
                    {
                        FileLoger.Info($"Invalid Token Type To Access Api  !" + Environment.NewLine +
                                $"IP:{ip}" + Environment.NewLine +
                                $"Token:{filterContext.HttpContext.Request.Headers["Token"][0]}");

                        filterContext.HttpContext.Response.StatusCode = 200;
                        filterContext.Result = new JsonResult(new
                        {
                            Message = "UnAuthorized Access. Invalid Token Type To Access Api  !",
                            Result = 200,
                            IsSuccessful = false
                        });
                    }
                    #endregion
                }
                else
                {
                    #region Not Existing Token
                    FileLoger.Info($"UnAuthorized Access To Api ! IP:{ip}");

                    filterContext.HttpContext.Response.StatusCode = 403;
                    filterContext.Result = new JsonResult(new
                    {
                        Message = "UnAuthorized Access. Token Not Sent.",
                        Result = 403,
                        IsSuccessful = false
                    });
                    #endregion
                }

                await base.OnActionExecutionAsync(filterContext, next);
            }
            catch (Exception e)
            {
                FileLoger.Error(e);
                filterContext.HttpContext.Response.StatusCode = 500;
                filterContext.Result = new JsonResult(new
                {
                    Result = 500,
                    IsSuccessful = false,
                    Message = "Internall Error."
                });

                await base.OnActionExecutionAsync(filterContext, next);
            }
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            try
            {
                var ip = ClientInfo.GetIP(filterContext.HttpContext);
                if (filterContext.HttpContext.Request.Headers["Token"].Count > 0)
                {
                    #region Existing Token
                    if (Guid.TryParse(filterContext.HttpContext.Request.Headers["Token"][0], out Guid token))
                    {
                        if (token == Guid.Parse(_configuration.GetSection("CustomSetting")["AuthenticateToken"]))
                        {
                            base.OnActionExecuting(filterContext);
                        }
                        else
                        {
                            FileLoger.Info($"Invalid Token To Access Api  !" + Environment.NewLine +
                                $"IP:{ip}" + Environment.NewLine +
                                $"Token:{filterContext.HttpContext.Request.Headers["Token"][0]}");

                            filterContext.HttpContext.Response.StatusCode = 200;
                            filterContext.Result = new JsonResult(new
                            {
                                Message = "UnAuthorized Access. Invalid Token To Access Api.",
                                Result = 200,
                                IsSuccessful = false
                            });
                        }
                    }
                    else
                    {
                        FileLoger.Info($"Invalid Token Type To Access Api  !" + Environment.NewLine +
                                $"IP:{ip}" + Environment.NewLine +
                                $"Token:{filterContext.HttpContext.Request.Headers["Token"][0]}");

                        filterContext.HttpContext.Response.StatusCode = 200;
                        filterContext.Result = new JsonResult(new
                        {
                            Message = "UnAuthorized Access. Invalid Token Type To Access Api  !",
                            Result = 200,
                            IsSuccessful = false
                        });
                    }
                    #endregion
                }
                else
                {
                    #region Not Existing Token
                    FileLoger.Info($"UnAuthorized Access To Api ! IP:{ip}");

                    filterContext.HttpContext.Response.StatusCode = 403;
                    filterContext.Result = new JsonResult(new
                    {
                        Message = "UnAuthorized Access. Token Not Sent.",
                        Result = 403,
                        IsSuccessful = false
                    });
                    #endregion
                }
            }
            catch (Exception e)
            {
                FileLoger.Error(e);
                filterContext.HttpContext.Response.StatusCode = 500;
                filterContext.Result = new JsonResult(new
                {
                    Result = 500,
                    IsSuccessful = false,
                    Message = "Internall Error."
                });
            }
        }
    }
}