using esluzba.DataAccess.Abstract;
using esluzba.DataAccess.Entities;
using esluzba.DataAccess.Repository.BaseRepository;

namespace esluzba.DataAccess.Repository.ServiceRepository;

public interface IServiceRepository : IBaseRepository<Service>
{
    Task<Service?> GetCurrentService(DateTime date, CancellationToken cancellationToken = default);
}