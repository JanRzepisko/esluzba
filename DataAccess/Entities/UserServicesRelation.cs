using esluzba.DataAccess.Abstract;

namespace esluzba.DataAccess.Entities;

public class UserServicesRelation : Entity
{
    public Guid UserId { get; set; }
    public User User { get; set; } = null!;
    public Guid ServiceId { get; set; }
    public Service? Service { get; set; }
}