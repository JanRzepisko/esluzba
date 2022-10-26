using esluzba.DataAccess.Entities;
using esluzba.Models;

namespace esluzba.Services.Admin;

public interface IAdminServices
{
    public Task<object> Login(string username, string password, CancellationToken cancellationToken = default);
    public Task<Parish> Register(Parish parish, CancellationToken cancellationToken = default);
    public Task<Parish> Update(Parish parish, CancellationToken cancellationToken = default);
    public Task Delete(Guid id, CancellationToken cancellationToken = default);
    public Task AddUser (User user, CancellationToken cancellationToken = default);
    public Task UpdateUser (User user, CancellationToken cancellationToken = default);
    public Task DeleteUser (Guid id, CancellationToken cancellationToken = default);
    public Task<List<Report>> GetReport(Guid id, int week, CancellationToken cancellationToken = default);
    public Task EditCalendar (List<Service> calendar, CancellationToken cancellationToken = default);
}