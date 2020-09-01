using Elk.Core;
using GolPooch.Domain.Entity;
using System.Threading.Tasks;

namespace GolPooch.Service.Interfaces
{
    public interface IUserService
    {
        /// <summary>
        /// Update Profile User And purchase a product that is not shown.
        /// at first, must check userid + mobilenumber for authentication. 
        /// if these two fields are ok, then update profile
        /// otherwise signout and return status code 401
        /// </summary>
        /// <param name="user">user information ( userid + mobilenumber are sent by jwt )</param>
        /// <returns>user id</returns>
        Task<IResponse<int>> UpdateProfile(User user);
    }
}
