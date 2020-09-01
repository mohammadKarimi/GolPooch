using Elk.Core;
using GolPooch.Domain.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GolPooch.Service.Interfaces
{
    public interface IChestService
    {
        /// <summary>
        /// Returns Available chest
        /// this method must be cached
        /// </summary>
        /// <returns>list of available chest</returns>
        Task<IResponse<List<Chest>>> GetAllAvailable();
    }
}
