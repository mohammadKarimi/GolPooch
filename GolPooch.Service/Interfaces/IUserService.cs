using Elk.Core;
using GolPooch.Domain.Entity;
using System;
using System.Threading.Tasks;

namespace GolPooch.Service.Interfaces
{
    public interface IUserService
    {
        /// <summary>
        /// Update Profile User with iscomplete=true And purchase a product that is not shown.
        /// at first, must check userid + mobilenumber for authentication. 
        /// if these two fields are ok, then update profile
        /// otherwise signout and return status code 401
        /// </summary>
        /// <param name="user">user information ( userid + mobilenumber are sent by jwt )</param>
        /// <returns>user id</returns>
        Task<IResponse<int>> UpdateProfile(User user);

        /// <summary>
        /// Upload awatar and save in host, and update user with awatar address
        /// </summary>
        /// <param name="userId">userid</param>
        /// <param name="photo">binary of photo</param>
        /// <returns>address of photo hosted</returns>
        Task<IResponse<string>> UploadAwatar(Guid userId, byte[] photo);
    }
}
