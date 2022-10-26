using esluzba.DataAccess.Abstract;
using esluzba.DataAccess.Entities;
using esluzba.DataAccess.Repository.AttendanceRepository;
using esluzba.DataAccess.Repository.BaseRepository;
using esluzba.DataAccess.Repository.ParishRepository;
using esluzba.DataAccess.Repository.ServiceRepository;
using Microsoft.EntityFrameworkCore;

namespace esluzba.DataAccess.DbContexts;

public class UserContext : DbContext, IUnitOfWork
{
    private DbSet<User>? _Users { get; set; }
    private DbSet<Parish>? _Parishes { get; set; }
    private DbSet<UserServicesRelation>? _UserServicesRelation { get; set; }
    private DbSet<Service>? _Services { get; set; }
    private DbSet<Attendance>? _Attendances { get; set; }

    public UserContext(DbContextOptions<UserContext> options) : base(options)
    {
    }
    public IBaseRepository<User> Users => new BaseRepository<User>(_Users);
    public IParishRepository Parishes => new ParishRepository(_Parishes);
    public IBaseRepository<UserServicesRelation> UserServicesRelations => new BaseRepository<UserServicesRelation>(_UserServicesRelation);
    public IServiceRepository Services => new ServiceRepository(_Services);
    public IAttendanceRepository Attendances => new AttendanceRepository(_Attendances);
}