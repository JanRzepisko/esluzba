namespace esluzba.Services.UserService;

public interface IUserService
{
    public Task AttestPresence(Guid id, string date, CancellationToken cancellationToken = default);
}