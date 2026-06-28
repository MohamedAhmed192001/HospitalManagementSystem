using HospitalManagementSystem.Application.Common.Interfaces;
using HospitalManagementSystem.Domain.Common;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Diagnostics;



namespace HospitalManagementSystem.Infrastructure.Data.Interceptors
{
    public class AuditableEntityInterceptor: SaveChangesInterceptor
    {
        private readonly IUser _user;
        private readonly TimeProvider _dateTime;

        public AuditableEntityInterceptor(IUser user,
            TimeProvider timeProvider)
        {
            _user = user;
            _dateTime = timeProvider;
        }

        public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
        {
            UpdateEntities(eventData.Context);
            return base.SavingChanges(eventData, result);
        }

        public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
        {
            UpdateEntities(eventData.Context);

            return base.SavingChangesAsync(eventData, result, cancellationToken);
        }

        public void UpdateEntities(DbContext? context)
        {
            if (context == null) return;

            foreach (var entry in context.ChangeTracker.Entries<BaseAuditableEntity>())
            {
                if(entry.State is EntityState.Added or EntityState.Modified || entry.hasChangedOwnedEntities())
                {
                    var utcNow = _dateTime.GetUtcNow();
                    if(entry.State == EntityState.Added)
                    {
                        entry.Entity.CreatedBy = _user.Id;
                        entry.Entity.Created = utcNow;
                    }

                    entry.Entity.LastModifiedBy = _user.Id;
                    entry.Entity.LastModified = utcNow;
                }
            }
        }

    }
}



public static class Extensions
{
    public static bool hasChangedOwnedEntities(this EntityEntry entry) =>
        entry.References.Any(r =>
        r.TargetEntry != null &&
        r.TargetEntry.Metadata.IsOwned() &&
        (r.TargetEntry.State == EntityState.Added || r.TargetEntry.State == EntityState.Modified)
        );
}