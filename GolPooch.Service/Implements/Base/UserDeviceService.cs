using Elk.Core;
using Elk.Http;
using System.Threading.Tasks;
using GolPooch.DataAccess.Ef;
using GolPooch.Domain.Entity;
using Microsoft.AspNetCore.Http;
using GolPooch.Service.Interfaces;

namespace GolPooch.Service.Implements
{
    public class UserDeviceService : IUserDeviceService
    {
        private AppUnitOfWork _appUow { get; set; }

        public UserDeviceService(AppUnitOfWork appUnitOfWork)
        {
            _appUow = appUnitOfWork;
        }

        public async Task<bool> AddAsync(HttpContext httpContext, long mobileNumber)
        {
            var clientRequestDetails = ClientInfo.GetRequestDetails(httpContext);
            var ip = ClientInfo.GetIP(httpContext);
            var isMobile = clientRequestDetails.IsNotNull() ? clientRequestDetails.IsMobile : false;
            var os = $"{clientRequestDetails?.OsName} {clientRequestDetails?.OsVersion}";
            var device = $"{clientRequestDetails?.Manufacture} {clientRequestDetails?.Model}";
            var application = $"{clientRequestDetails?.BrowserName} {clientRequestDetails?.BrowserVersion}";

            await _appUow.UserDeviceRepo.AddAsync(new UserDevice
            {
                MobileNumber = mobileNumber,
                IP = ip,
                IsMobile = isMobile,
                Os = os.Length < 20 ? os : os.Substring(0, 20),
                Device = device.Length < 50 ? device : device.Substring(0, 50),
                Application = application.Length < 50 ? application : application.Substring(0, 50)
            });

            var saveResult = await _appUow.ElkSaveChangesAsync();
            return saveResult.IsSuccessful;
        }
    }
}