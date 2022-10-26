using esluzba.Enums;

namespace esluzba.Models;

public class Event
{
    public DayOfWeek Day { get; set; }
    public DateTime Date { get; set; }
    public EventType Type { get; set; }
}