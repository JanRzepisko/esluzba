using esluzba.DataAccess.Abstract;
using esluzba.Enums;

namespace esluzba.DataAccess.Entities;

public class Service : Entity
{
    public Guid ParishId { get; set; }
    public Parish Parish { get; set; } = null!;
    public DayOfWeek Day { get; set; }
    public TimeSpan StartTime { get; set; }
    public EventType Type { get; set; }
    public ICollection<UserServicesRelation> Users { get; set; } = null!;
}