﻿using Elk.Core;
using GolPooch.Domain.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GolPooch.Service.Interfaces
{
    public interface IBannerService
    {
        /// <summary>
        /// Returns Available Banner ( expiration time & is active ) 
        /// this method must cached and returned from cache.
        /// each record must be included with page property 
        /// </summary>
        /// <returns>list of banner</returns>
        Task<IResponse<List<Banner>>> GetAllAvailable();
    }
}
