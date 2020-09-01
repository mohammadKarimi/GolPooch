using Elk.Core;
using GolPooch.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GolPooch.Service.Interfaces
{
    public interface ITicketService
    {
        /// <summary>
        /// Get ticket with userid and ticket parameter
        /// </summary>
        /// <param name="userid">userid that is filled from jwt</param>
        /// <param name="ticketId">ticket primary key</param>
        /// <returns>list of ticket model</returns>
        Task<IResponse<List<Ticket>>> Get(Guid userid, int ticketId);

        /// <summary>
        /// Get Top 10 tickets of user
        /// </summary>
        /// <param name="userId">userid that is filled from jwt</param>
        /// <returns>lsit of tickets model</returns>
        Task<IResponse<List<Ticket>>> Get(Guid userId);

        /// <summary>
        /// Add ticket for user
        /// </summary>
        /// <param name="model">model that is filled by user in clientside</param>
        /// <returns>return ticket primary key</returns>
        Task<IResponse<int>> Add(Ticket model);
    }
}
