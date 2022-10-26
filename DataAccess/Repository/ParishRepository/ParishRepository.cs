using esluzba.DataAccess.Entities;
using esluzba.DataAccess.Repository.BaseRepository;
using Microsoft.EntityFrameworkCore;

namespace esluzba.DataAccess.Repository.ParishRepository;

internal sealed class ParishRepository : BaseRepository<Parish>, IParishRepository
{
    public ParishRepository(DbSet<Parish>? entities) : base(entities){ }

    public Task<Parish> GetByLogin(string login, CancellationToken cancellationToken)
    {
        return _entities.FirstOrDefaultAsync(c => c.Email == login, cancellationToken)!;
    }

    public Task<bool> IsLoginExistAsync(string login, CancellationToken cancellationToken)
    {
        return _entities.AnyAsync(c => c.Email == login, cancellationToken);
    }
}