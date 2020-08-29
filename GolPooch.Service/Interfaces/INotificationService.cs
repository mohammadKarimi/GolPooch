using Elk.Core;
using GolPooch.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GolPooch.Service.Interfaces
{
    public interface INotificationService
    {

        /// <summary>
        /// Get top 10 notifications with userid and all notification that sets userid with null value.
        /// </summary>
        /// <param name="userId">userid in jwt</param>
        /// <returns>Top 10 records of Notification</returns>
        Task<IResponse<List<Notification>>> GetTopNotifications(Guid userId);

        /// <summary>
        /// Add delivery of notification in notificationDelivery Table
        /// </summary>
        /// <param name="userId">read from jwt</param>
        /// <param name="notificationId">get this id from push message</param>
        /// <returns>return notification id</returns>
        Task<IResponse<int>> AddDelivery(Guid userId, int notificationId);
    }
}
