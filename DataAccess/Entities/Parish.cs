using esluzba.DataAccess.Abstract;


namespace esluzba.DataAccess.Entities;

public class Parish : Entity
{
    public string Name { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string PasswordHash { get; set; } = null!;
    public ICollection<User> Users { get; set; } = null!;
}