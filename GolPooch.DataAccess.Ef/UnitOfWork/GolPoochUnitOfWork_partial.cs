using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Threading;
using System.Threading.Tasks;
using GolPooch.DataAccess.Ef;
using Elk.EntityFrameworkCore;

namespace GolPooch.DataAccess.Ef
{
    public partial class GolPoochUnitOfWork
    {
        private readonly GolPoochDbContext _golPoochDbContext; private readonly IServiceProvider _serviceProvider;
        public GolPoochUnitOfWork(GolPoochDbContext golPoochDbContext, IServiceProvider serviceProvider)
        {
            _golPoochDbContext = golPoochDbContext;
            _serviceProvider = serviceProvider;
        }

        public ChangeTracker ChangeTracker { get => _golPoochDbContext.ChangeTracker; }
        public DatabaseFacade Database { get => _golPoochDbContext.Database; }

        public SaveChangeResult ElkSaveChanges() => _golPoochDbContext.ElkSaveChanges();

        public Task<SaveChangeResult> ElkSaveChangesAsync(CancellationToken cancellationToken = default)
            => _golPoochDbContext.ElkSaveChangesAsync(cancellationToken);

        public SaveChangeResult ElkSaveChangesWithValidation()
            => _golPoochDbContext.ElkSaveChangesWithValidation();

        public Task<SaveChangeResult> ElkSaveChangesWithValidationAsync(CancellationToken cancellationToken = default)
            => _golPoochDbContext.ElkSaveChangesWithValidationAsync(cancellationToken);

        public int SaveChanges()
            => _golPoochDbContext.SaveChanges();

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
            => _golPoochDbContext.SaveChangesAsync(cancellationToken);

        public Task<int> SaveChangesAsync(bool AcceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
            => _golPoochDbContext.SaveChangesAsync(AcceptAllChangesOnSuccess, cancellationToken);

        public void Dispose() => _golPoochDbContext.Dispose();
    }
}
