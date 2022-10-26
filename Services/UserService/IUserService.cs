namespace esluzba.Services.UserService;

public interface IUserService
{
    public Task AttestPresence(string fingerprint);
}