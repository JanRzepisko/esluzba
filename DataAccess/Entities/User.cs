using esluzba.DataAccess.Abstract;

namespace esluzba.DataAccess.Entities;

public class User : Entity
{
    public string Name { get; set; } = null!;
    public string Surname { get; set; } = null!;
    public string FingerprintCode { get; set; } = null!;
    public Parish Parish { get; set; } = null!;
    public Guid ParishId { get; set; }
    public ICollection<UserServicesRelation> MyServices { get; set; } = null!;
    public ICollection<Attendance> MyAttendance { get; set; } = null!; 
}