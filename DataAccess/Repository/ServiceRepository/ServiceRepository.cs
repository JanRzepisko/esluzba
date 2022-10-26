using esluzba.DataAccess.Entities;
using esluzba.DataAccess.Repository.BaseRepository;
using Microsoft.EntityFrameworkCore;

namespace esluzba.DataAccess.Repository.ServiceRepository;

public class ServiceRepository : BaseRepository<Service>,  IServiceRepository
{
    public ServiceRepository(DbSet<Service>? entities) : base(entities)
    {
    }

    public Task<Service?> GetCurrentService(DateTime date, CancellationToken cancellationToken = default)
    {
        return _entities.Where(c => c.Day == date.DayOfWeek && c.StartTime >= date.TimeOfDay - TimeSpan.FromMinutes(20)  && c.StartTime >= date.TimeOfDay + TimeSpan.FromMinutes(5)).FirstOrDefaultAsync(cancellationToken);
    }
}