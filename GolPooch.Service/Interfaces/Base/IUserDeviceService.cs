using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace GolPooch.Service.Interfaces
{
    public interface IUserDeviceService
    {
        /// <summary>
        /// Add User Device, Os and Browser Log 
        /// </summary>
        /// <param name="httpContext">httpContext of user request</param>
        /// <returns>Add Is Successful Or Not</returns>
        Task<bool> AddAsync(HttpContext httpContext, long mobileNumber);
    }
}