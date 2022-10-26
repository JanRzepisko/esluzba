using esluzba.DataAccess.Abstract;
using esluzba.DataAccess.Entities;
using esluzba.Exceptions;

namespace esluzba.Services.UserService;

public class UserService : IUserService
{
    private readonly IUnitOfWork _unitOfWork;
    
    public UserService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    
    public async Task AttestPresence(Guid id, string date, CancellationToken cancellationToken = default)
    {
        var parsedDate = DateTime.Parse(date);
        
        if (!await _unitOfWork.Users.ExistsAsync(id, cancellationToken))
        {
            throw new Conflict("User not found");
        }
        var service = await _unitOfWork.Services.GetCurrentService(parsedDate, cancellationToken);
        if (service == null)
        {
            throw new Conflict("Service not found");
        }
        
        await _unitOfWork.Attendances.AddAsync(new Attendance
        {
            Date = parsedDate,
            ServiceId = service.Id,
            UserId = id
        }, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}