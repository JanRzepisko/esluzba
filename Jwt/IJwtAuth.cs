namespace esluzba.Jwt;

public interface IJwtAuth
{
    public Task<string> GenerateJwt(Guid id, string role);
}