using esluzba.DataAccess.Entities;
using esluzba.DataAccess.Repository.BaseRepository;

namespace esluzba.DataAccess.Repository.ParishRepository;

public interface IParishRepository : IBaseRepository<Parish>
{

    public Task<Parish> GetByLogin(string login, CancellationToken cancellationToken);
    public Task<bool> IsLoginExistAsync(string login, CancellationToken cancellationToken);

}