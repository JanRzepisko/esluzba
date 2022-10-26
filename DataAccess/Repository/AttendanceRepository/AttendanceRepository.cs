using esluzba.DataAccess.Entities;
using esluzba.DataAccess.Repository.BaseRepository;
using Microsoft.EntityFrameworkCore;

namespace esluzba.DataAccess.Repository.AttendanceRepository;

public class AttendanceRepository : BaseRepository<Attendance>, IAttendanceRepository
{
    public AttendanceRepository(DbSet<Attendance>? entities) : base(entities)
    {
    }

    public Task<List<Attendance>> GetForUserAsync(Guid id, DateTime start, int asFarAs, CancellationToken cancellationToken)
    {
        return _entities.Where(c => c.UserId == id && c.Date >= start && c.Date <= start.AddDays(asFarAs)).ToListAsync(cancellationToken);
    }
}