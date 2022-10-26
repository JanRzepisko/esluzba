using esluzba.DataAccess.Abstract;
using esluzba.Enums;

namespace esluzba.DataAccess.Entities;

public class Attendance : Entity
{
    public Guid UserId { get; set; }
    public User User { get; set; }
    public DateTime Date { get; set; }
    public Guid ServiceId { get; set; }
    public Service Service { get; set; }
    public EventType Type { get; set; }
    public AttendanceType Status { get; set; }
}