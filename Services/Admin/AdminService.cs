using esluzba.DataAccess.Abstract;
using esluzba.DataAccess.Entities;
using esluzba.Enums;
using esluzba.Jwt;
using esluzba.Models;
using Microsoft.AspNetCore.Mvc;
using Conflict = esluzba.Exceptions.Conflict;

namespace esluzba.Services.Admin;

public class AdminService : IAdminServices
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IJwtAuth _jwtAuth;
    
    public AdminService(IUnitOfWork unitOfWork, IJwtAuth jwtAuth)
    {
        _unitOfWork = unitOfWork;
        _jwtAuth = jwtAuth;
    }
    
    public async Task<IActionResult> Login(string username, string password, CancellationToken cancellationToken = default)
    {
        var exist = await _unitOfWork.Parishes.IsLoginExistAsync(username, cancellationToken);
        if (!exist)
        {
            throw new Conflict("Username is incorrect");
        }
        Parish parish = await  _unitOfWork.Parishes.GetByLogin(username, cancellationToken);
        
        if(!BCrypt.Net.BCrypt.Verify(password, parish.PasswordHash))
        {
            throw new Conflict("Password is incorrect");
        }

        string jwt = await _jwtAuth.GenerateJwt(parish.Id, JwtPolicies.Admin);

        parish.PasswordHash = string.Empty;
        
        return new OkObjectResult(new
        {
            parish,
            jwt
        });
    }
    
    //TODO: mail email password to parish 
    public async Task<IActionResult> Register(Parish parish, CancellationToken cancellationToken = default)
    {
        await _unitOfWork.Parishes.AddAsync(parish, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return new OkObjectResult(parish);
    }

    public async Task<Parish> Update(Parish parish, CancellationToken cancellationToken = default)
    {
        _unitOfWork.Parishes.Update(parish);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return parish;
    }
    
    public Task Delete(Guid id, CancellationToken cancellationToken = default)
    {
        _unitOfWork.Parishes.RemoveById(id);
        return _unitOfWork.SaveChangesAsync(cancellationToken);
    }

    public async Task AddUser(User user, CancellationToken cancellationToken = default)
    {
        await _unitOfWork.Users.AddAsync(user, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }

    public Task UpdateUser(User user, CancellationToken cancellationToken = default)
    {
        _unitOfWork.Users.Update(user);
        return _unitOfWork.SaveChangesAsync(cancellationToken);
    }

    public Task DeleteUser(Guid id, CancellationToken cancellationToken = default)
    {
        _unitOfWork.Parishes.RemoveById(id);
        return _unitOfWork.SaveChangesAsync(cancellationToken);
    }

    public async Task<List<Report>> GetReport(Guid id, int week, CancellationToken cancellationToken = default)
    {
        List<Report> reports = new List<Report>();
        
        int allTime =  week * 7 * -1;
        
        var start = DateTime.Today.AddDays((-(int)DateTime.Today.DayOfWeek) + allTime);
        int asFarAs = 7;

        Parish? parish = await _unitOfWork.Parishes.GetByIdAsync(id, cancellationToken);
        foreach (User user in parish!.Users)
        {
            Report report = new Report(user);
            List<Attendance> attendances = await _unitOfWork.Attendances.GetForUserAsync(user.Id, start, asFarAs, cancellationToken);
            List<Service?> myServices = user.MyServices.Select(c => c.Service).ToList();

            //Add point for each attendance
            foreach (Attendance @event in attendances)
            {
                if (@event.Type == EventType.Msza)
                {
                    if (@event.Status == AttendanceType.Compulsory)
                    {
                        report.Compulsory.Add(new Event()
                        {
                            Date = @event.Date,
                            Day = @event.Date.DayOfWeek,
                            Type = @event.Type
                        });
                    }
                    else if (@event.Status == AttendanceType.AboveServices)
                    {
                        report.AboveServices.Add(new Event()
                        {
                            Date = @event.Date,
                            Day = @event.Date.DayOfWeek,
                            Type = @event.Type
                        });
                    }
                }
                else if (@event.Type == EventType.Nabozenstwo && @event.Status == AttendanceType.Devotions)
                {
                    report.Devotions.Add(new Event()
                    {
                        Date = @event.Date,
                        Day = @event.Date.DayOfWeek,
                        Type = @event.Type
                    });
                }
            }

            
            List<Event> myServicesEvents = new List<Event>();
            for (int i = 0; i < week; i++)
            {
                foreach (Service service in myServices)
                {
                    DateTime date = DateTime.Today.AddDays((-(int) DateTime.Today.DayOfWeek) + (int) service!.Day - (i*7));

                    myServicesEvents.Add(new Event()
                    {
                        Date = date + service.StartTime,
                        Day = date.DayOfWeek,
                        Type = EventType.Msza
                    });
                }
            }

        }

        return reports;
    }

    public Task EditCalendar(List<Service> calendar, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}