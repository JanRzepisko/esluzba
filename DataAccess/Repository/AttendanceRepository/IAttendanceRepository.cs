using esluzba.DataAccess.Entities;
using esluzba.DataAccess.Repository.BaseRepository;

namespace esluzba.DataAccess.Repository.AttendanceRepository;

public interface IAttendanceRepository : IBaseRepository<Attendance>
{
    Task<List<Attendance>> GetForUserAsync(Guid id, DateTime start, int asFarAs, CancellationToken cancellationToken);
}