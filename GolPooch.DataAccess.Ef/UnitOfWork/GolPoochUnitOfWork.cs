using Elk.Core;
using Elk.EntityFrameworkCore;
using GolPooch.Domain.Entity;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace GolPooch.DataAccess.Ef
{
    public partial class GolPoochUnitOfWork : IElkUnitOfWork
    {
        public IGenericRepo<User> UserRepo => _serviceProvider.GetService<IGenericRepo<User>>();
    }
}
