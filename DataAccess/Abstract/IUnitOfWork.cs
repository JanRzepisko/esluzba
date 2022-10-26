using System.Data.Entity;
using esluzba.DataAccess.DbContexts;
using esluzba.DataAccess.Entities;
using esluzba.DataAccess.Repository.AttendanceRepository;
using esluzba.DataAccess.Repository.BaseRepository;
using esluzba.DataAccess.Repository.ParishRepository;

namespace esluzba.DataAccess.Abstract;

public interface IUnitOfWork
{
    IBaseRepository<User> Users { get; }
    IParishRepository Parishes { get; }
    IBaseRepository<UserServicesRelation> UserServicesRelations { get; }
    IBaseRepository<Service> Services { get; }
    IAttendanceRepository Attendances { get; }
    int SaveChanges();
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}