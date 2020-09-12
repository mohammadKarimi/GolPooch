using System;
using Elk.Core;
using Elk.Cache;
using GolPooch.Api.Models;
using GolPooch.CrossCutting;
using GolPooch.Domain.Entity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace GolPooch.Api.Controllers
{
    [Route("[controller]/[action]")]
    public class BaseController : Controller
    {
        private readonly IMemoryCacheProvider _cacheProvider;

        public BaseController(IMemoryCacheProvider cacheProvider)
        {
            _cacheProvider = cacheProvider;
        }
        private readonly string _regionCacheKey = GlobalVariables.CacheSettings.RegionCacheKey();

        private List<Region> GetRegions()
        {
            var response = new List<Region>();
            try
            {
                response = (List<Region>)_cacheProvider.Get(_regionCacheKey);
                if (response == null)
                {
                    response = new List<Region>();
                    EnumExtension.GetEnumElements<RegionNames>()
                        .ForEach(element =>
                        {
                            response.Add(new Region { Name = element.Description, Value = int.Parse(element.Value.ToString()) });
                        });

                    _cacheProvider.Add(_regionCacheKey, response, DateTime.Now.AddHours(GlobalVariables.CacheSettings.RegionCacheTimeout()));
                }

                return response;
            }
            catch (Exception e)
            {
                FileLoger.Error(e);
                return response;
            }
        }


        /// <summary>
        /// Return Region Enum in key,Value model
        /// result of this method must be cached.
        /// </summary>
        /// <returns>List of Key,Value Object</returns>
        [HttpGet]
        public IActionResult Regions() 
            => Ok(GetRegions());

    }
}